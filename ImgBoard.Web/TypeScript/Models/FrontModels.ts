namespace FrontModels {

    export class Tag {
        Id: number;
        Name: string;

        constructor(tag: Models.ITag) {
            this.Id = tag.Id;
            this.Name = tag.Name;
        }
    }

    export class Image {
        UploaderLogin: string;
        FileUrl: string;
        Name: string;
        Description: string;
        Tags: Array<Tag>;

        constructor(image: Models.IImage) {
            this.UploaderLogin = "Uploaded by @"+image.Uploader.Login;
            this.FileUrl = "http://localhost/imgBoardContent/" + image.FileId + "." + image.FileExtension;
            this.Name = image.Name;
            this.Description = image.Description;
            this.Tags = image.Tags.map(el => new Tag(el));
        }
    }

}