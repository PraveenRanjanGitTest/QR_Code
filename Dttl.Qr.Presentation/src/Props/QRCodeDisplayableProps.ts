import { DefaultTemplateProps } from "./TemplateProps";

export interface QRCodeDisplayableProps extends DefaultTemplateProps {
    TargetUrl: string;
    RenderType: string;
    level: string;
    marginRequired: boolean;
    DivId: string;
}

export default QRCodeDisplayableProps;