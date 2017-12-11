namespace ViewModels {
    export class BoardViewModel {
        LastFetchedTerm: string;

        Action: KnockoutObservable<string>;
        Images: KnockoutObservableArray<FrontModels.Image>;
        Term: KnockoutObservable<string>;
        Matches: KnockoutObservableArray<FrontModels.Category>;

        Search: () => void;
        FetchImagesByMatch: (match: FrontModels.Category) => void;

        ApplySearchResult: (action: string, images: Array<Models.IImage>, timeStart: number) => void;

        constructor(images: Array<Models.IImage>) {
            this.LastFetchedTerm = "";
            this.Action = ko.observable("All images");
            this.Term = ko.observable("");
            this.Images = ko.observableArray(images.map(el => new FrontModels.Image(el)));
            this.Matches = ko.observableArray([]);

            this.Search = () => {
                let timeStart = Date.now();
                
                let term = this.Term();

                if (term.length === 0) {
                    $('#main-throbber').show();
                    $('.images-grid').hide();

                    ApiRequests.GetImagesRequest(images => {
                        this.ApplySearchResult("All images", images, timeStart);
                    });
                } else {
                    if (this.LastFetchedTerm !== term) {
                        ApiRequests.GetMatchingCategories(term, categories => {
                            this.Matches(categories.map(el => new FrontModels.Category(el)));
                            $('#search-matches').show();
                        });
                    }
                }
            };

            this.FetchImagesByMatch = (match: FrontModels.Category) => {
                let timeStart = Date.now();

                this.Term(match.Title);
                this.LastFetchedTerm = match.Title;

                $('#search-matches').hide();
                $('#main-throbber').show();
                $('.images-grid').hide();

                ApiRequests.GetImagesByCategory(match.Id, images => {
                    this.ApplySearchResult("Matches for : " + match.Title, images, timeStart);
                });
            };

            this.ApplySearchResult = (
                action: string,
                images: Array<Models.IImage>,
                timeStart: number
            ) => {
                this.Action(action);
                this.Images(images.map(el => new FrontModels.Image(el)));
                Util.SetMinimumTimeout(timeStart, 500, ViewsCode.ResetBoardDom);
            };
        }
    }
}