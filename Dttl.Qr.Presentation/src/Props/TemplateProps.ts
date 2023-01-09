export interface TemplateProps {
    ForeColor: string;
    BackgroundColor: string;
    Height: number;
    Width: number;
    Logo: string;
    CreatedBy: string;
    TemplateName: string;
}

export interface TemplateUpdateProps extends TemplateProps {
    ModifiedBy: string;
}