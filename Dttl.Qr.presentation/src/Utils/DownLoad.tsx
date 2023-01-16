import jsPDF from 'jspdf';

let nameofthefile = "qrcode.";

export function downloadQrCodecAsBase64(SvgElementId: string) {
    var svg = getSvgElement(SvgElementId);
    var xml = new XMLSerializer().serializeToString(svg);
    var svg64 = btoa(xml);
    var b64Start = 'data:image/svg+xml;base64,';
    var image64 = b64Start + svg64;
    return image64;
}

export function downloadQrCode(SvgElementId: string, imageType: string) {
    var svg = getSvgElement(SvgElementId);
    let width = svg.clientWidth;
    let height = svg.clientHeight;
    var image64 = downloadQrCodecAsBase64(SvgElementId);

    const image = document.createElement("img")
    image.src = image64;

    var canvasElement = document.createElement('canvas');
    canvasElement.id = "canvasqrid";
    canvasElement.width = width;
    canvasElement.height = height;
    let context = canvasElement.getContext('2d');

    image.onload = function () {
        context?.drawImage(image, 0, 0, width, height);
        downLoad(image64, canvasElement, imageType, width, height);
    }
}
function downLoad(imagesrc: string, canvasElement: HTMLElement, type: string, width: number, height: number) {
    switch (type.toLowerCase()) {
        case 'svg':
            downloadQrCodeSvg(imagesrc, type);
            break;
        case 'pdf':
            downloadQrCodePdf(canvasElement, type);
            break;
        default:
            downloadQrCodeImage(canvasElement, type);
            break;
    }
}
function getSvgElement(SvgElementId: string) {
    return document.getElementById(SvgElementId) as unknown as SVGAElement;
}

function downloadQrCodeImage(canvasElement: HTMLElement, imageType: string) {
    const canvas = canvasElement as unknown as HTMLCanvasElement;
    const anchor = document.createElement("a");
    anchor.href = canvas.toDataURL("image/" + imageType);
    anchor.download = nameofthefile + imageType;
    anchor.click();
}
function downloadQrCodePdf(canvasElement: HTMLElement, type: string) {
    const canvas = canvasElement as unknown as HTMLCanvasElement;

    const image = canvas.toDataURL('image/jpeg', 1.0);
    const doc = new jsPDF('p', 'px', 'a4');
    const pageWidth = doc.internal.pageSize.getWidth();
    const pageHeight = doc.internal.pageSize.getHeight();

    const widthRatio = pageWidth / canvas.width;
    const heightRatio = pageHeight / canvas.height;
    const ratio = widthRatio > heightRatio ? heightRatio : widthRatio;

    const canvasWidth = canvas.width * ratio;
    const canvasHeight = canvas.height * ratio;

    const marginX = (pageWidth - canvasWidth) / 2;
    const marginY = (pageHeight - canvasHeight) / 2;

    doc.addImage(image, 'JPEG', marginX, marginY, canvasWidth, canvasHeight);

    doc.save(nameofthefile + type);
}
function downloadQrCodeSvg(imagesrc: string, type: string) {
    const anchor = document.createElement("a");
    anchor.href = imagesrc;
    anchor.download = nameofthefile + type;
    anchor.click();
}