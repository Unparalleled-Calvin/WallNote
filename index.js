var electron = require('electron');
var app = electron.app;

// const { app } = require('electron')
var win = null;

const gotTheLock = app.requestSingleInstanceLock()

if (!gotTheLock) {
    app.quit();
} else {
    app.on('second-instance', (event, commandLine, workingDirectory) => {
        // Someone tried to run a second instance, we should focus our window.
        if (win) {
            win.focus();
        }
    })
    var BrowserWindow = electron.BrowserWindow;

    app.on('ready', function () {
        let rootPath = app.getAppPath() + "\\";
        let winBounds;
        try {
            winBounds = JSON.parse(require('fs').readFileSync(rootPath + 'record.json'));
        }
        catch (ReferenceError) {
            winBounds = { "width": 300, "height": 100, "x": 490, "y": 290, "mode": "A" };
        }
        win = new BrowserWindow({
            webPreferences: {
                nodeIntegration: true,
                contextIsolation: false,
                enableRemoteModule: true,
            },
            width: winBounds.width,
            height: winBounds.height + 70,
            x: winBounds.x,
            y: winBounds.y,
            transparent: true,
            frame: false,
        });
        //打开控制台
        // win.webContents.openDevTools({
        //     mode: "bottom"
        // });

        //任务栏不显示
        win.setSkipTaskbar(true);

        //根据存档决定是否开机自启动
        app.setLoginItemSettings({
            openAtLogin: winBounds.mode == "A", // Boolean 在登录时启动应用
            openAsHidden: winBounds.mode == "A", // Boolean (可选) mac 表示以隐藏的方式启动应用。
        });

        win.loadFile('index.html');
        win.on('closed', function () {
            win = null;
        });


        let { ipcMain } = require('electron')
        ipcMain.on('resize', (event, e) => {
            win.setSize(e.width, e.height + 70)
        });
        ipcMain.on('close', (event) => {
            win = null;
            app.exit();
        });
        ipcMain.on('open', (event, e) => {
            app.setLoginItemSettings({
                openAtLogin: e.mode == "A",
                openAsHidden: e.mode == "A"
            });
        });
    });
    app.on('window-all-closed', function () {
        app.quit();
    });
}