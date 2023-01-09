export interface DefaultTemplateProps {
    ForeColor: string;
    BackgroundColor: string;
    Height: number;
    Width: number;
    Logo: string;
    CreatedBy: string;
    TemplateName: string;
}

export interface TemplateProps extends DefaultTemplateProps {
    TemplateId: string;
    CreatedDate: Date;
    ModifiedBy: string;
    ModifiedDate: Date;
    IsActive: boolean;
    IsApproved: boolean;
}

export interface TemplateList  {

    templates: TemplateProps[];
  
}
