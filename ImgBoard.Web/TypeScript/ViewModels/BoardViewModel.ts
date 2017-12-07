namespace ViewModels {
    export class BoardViewModel {
        Images: KnockoutObservableArray<FrontModels.Image>;

        constructor(images: Array<Models.IImage>) {
            this.Images = ko.observableArray(images.map(el => new FrontModels.Image(el)));
        }
    }
}