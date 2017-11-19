import Category from "./Category";
import User from "./User";

export default interface Image {
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