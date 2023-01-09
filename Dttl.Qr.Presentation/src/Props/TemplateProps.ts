import { DefaultTemplateProps } from "./DefaultTemplateProps";

export interface TemplateProps extends DefaultTemplateProps {
    
    TemplateId: string;
    CreatedDate: Date;
    ModifiedBy: string;
    ModifiedDate: Date;
    IsActive: boolean;
    IsApproved: boolean;
}