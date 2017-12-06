namespace Models {

    export interface Category {
        Id: number;

        Title: string;
    }

    export interface User {
        Id: number;

        Login: string;
        Password: string;
        UserName: string;
    }

    export interface Image {
        Id: number;
        IdCategory?: number;
        IdUploader: number;

        Name: string;
        Description: string;
        FileId: string;
        FileExtension: string;

        Category: Category;
        Uploader: User;
    }
    
}