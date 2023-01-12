import * as React from "react";
import jsPDF from 'jspdf';

let nameofthefile = "qrcode.";
function downloadQrCodeImage(canvasElement: any, imageType: string, width: number, height: number) {
    const canvas = canvasElement as unknown as HTMLCanvasElement;
    const anchor = document.createElement("a");
    anchor.href = canvas.toDataURL("image/" + imageType);
    anchor.download = nameofthefile + imageType;
    anchor.click();
}
function downloadQrCodePdf(canvasElement: any, type: string, width: number, height: number) {
    const canvas = canvasElement as unknown as HTMLCanvasElement;

    let png = canvas.toDataURL("image/png");
    const pdf = new jsPDF();
    pdf.addImage(png, 'JPEG', 0, 0, width, width);
    pdf.save(nameofthefile + type);
}
function downloadQrCodeSvg(imagesrc: string, type: string, width: number, height: number) {
    const anchor = document.createElement("a");
    anchor.href = imagesrc;
    anchor.download = nameofthefile + type;
    anchor.click();
}

function downLoad(imagesrc: string, canvasElement: any, type: string, width: number, height: number) {
    switch (type.toLowerCase()) {
        case 'svg':
            downloadQrCodeSvg(imagesrc, type, width, height);
            break;
        case 'pdf':
            downloadQrCodePdf(canvasElement, type, width, height);
            break;
        default:
            downloadQrCodeImage(canvasElement, type, width, height);
            break;
    }
}

export function downloadQrCode(SvgElementId: string, imageType: string) {
    let canvasId = 'qrCodeCanvas';
    var svg = document.getElementById(SvgElementId) as unknown as SVGAElement;
    let { width, height } = svg.getBBox();
    var xml = new XMLSerializer().serializeToString(svg);

    var svg64 = btoa(xml);
    var b64Start = 'data:image/svg+xml;base64,';
    var image64 = b64Start + svg64;

    const image = document.createElement("img")

    image.src = image64;

    var canvasElement = document.createElement('canvas');
    canvasElement.id = canvasId;
    canvasElement.width = width;
    canvasElement.height = height;
    let context = canvasElement.getContext('2d');

    image.onload = function () {
        context?.drawImage(image, 0, 0, width, height);
        downLoad(image64, canvasElement, imageType, width, height);
    }
}