namespace ViewModels {
    export class BoardViewModel {
        Images: KnockoutObservableArray<FrontModels.Image>;
        Search: () => void;
        Term: KnockoutObservable<string>;

        constructor(images: Array<Models.IImage>) {
            this.Term = ko.observable("");
            this.Images = ko.observableArray(images.map(el => new FrontModels.Image(el)));

            this.Search = () => {
                let timeStart = Date.now();
                
                let term = this.Term();
                if (term.length === 0) return;

                $('#mainThrobber').toggle();
                $('.imagesGrid').toggle();

                ApiRequests.GetImagesMatchingCategory(term, images => {
                    this.Images(images.map(el => new FrontModels.Image(el)));

                    Util.SetMinimumTimeout(timeStart, 500, ViewsCode.ResetBoardDom);
                });
            }
        }
    }
}