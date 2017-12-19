namespace ApiModels {

    export interface GetImagesParameters {
        TagsIds: Array<number>,
        CategoriesIds: Array<number>,
        Name: string,
        Description: string,
        Uploader: string,
        Extension: string
    }
}