namespace ViewsCode {
    export function Board() {
        let timeStart = Date.now();
        ApiRequests.GetImagesRequest(images => {
            ko.applyBindings(new ViewModels.BoardViewModel(images));

            Util.SetMinimumTimeout(timeStart, 500, this.SetupBoardDom);
        });
    }

    export function SetupBoardDom() {
        $('.imagesGrid').imagesLoaded().progress(function () {
            $('#gridContent').masonry({
                itemSelector: '.grid-item',
                columnWidth: '.grid-sizer',
                percentPosition: true
            });
        });
        $('#mainThrobber').toggle();
        $('.imagesGrid').fadeIn();
    }
}