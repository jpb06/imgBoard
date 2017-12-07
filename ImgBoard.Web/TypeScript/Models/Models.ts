namespace Models {

    export interface ITag {
        Id: number;

        Name: string;
    }

    export interface ICategory {
        Id: number;

        Title: string;
    }

    export interface IUser {
        Id: number;

        Login: string;
        Password: string;
        UserName: string;
    }

    export interface IImage {
        Id: number;
        IdCategory?: number;
        IdUploader: number;

        Name: string;
        Description: string;
        FileId: string;
        FileExtension: string;

        Category: ICategory;
        Uploader: IUser;
        Tags: Array<ITag>;
    }
    
}