import { DefaultTemplateProps, TemplateProps } from "./TemplateProps";

export interface QRCodeDisplayableProps extends TemplateProps {
    TargetUrl: string;
    RenderType: string;
    level: string;
    marginRequired: boolean;
    DivId: string;
}

export default QRCodeDisplayableProps;