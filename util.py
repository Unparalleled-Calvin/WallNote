from PIL import Image, ImageDraw, ImageFont
import argparse
parser = argparse.ArgumentParser(description='Test')
parser.add_argument('--path', '-p', help='Image Path')
parser.add_argument('--note', '-n', help='Note Content')
parser.add_argument('--color', '-c', help='Note Color')
parser.add_argument('--location', '-l', help='Note Position')
parser.add_argument('--size', '-s', help='Font Size')
args = parser.parse_args()


ImagePath = args.path.replace("/", " ")
Text = args.note.replace("\\n","\n").replace("/", " ").replace("\\-", "-")
TextColor = tuple(int(i) for i in args.color.split(','))
TextSize = 10 * int(args.size)
TextPos = tuple(float(i) for i in args.location.split(','))

def image_add_text(img_path, text, text_color, text_size, pos):
    img = Image.open(img_path)
    draw = ImageDraw.Draw(img)
    fontStyle = ImageFont.truetype("simhei.ttf", text_size, encoding="utf-8")
    noteSize = fontStyle.getsize(text)
    draw.text((img.size[0]*pos[0] - noteSize[0]/2, img.size[1]*pos[1] - noteSize[1]/2), text, text_color, font=fontStyle)
    return img

im = image_add_text(ImagePath, Text, TextColor, TextSize, TextPos)
im.save('temp.jpg')

import ctypes
import os

SPI_SETDESKWALLPAPER = 20

ctypes.windll.user32.SystemParametersInfoW(SPI_SETDESKWALLPAPER, 0, os.getcwd() + '\\' + 'temp.jpg', 3)
os.remove('temp.jpg')
