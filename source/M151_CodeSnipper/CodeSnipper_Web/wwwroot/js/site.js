$(document).ready(function ($) {
    $(".copyContentButton").click(function () {
        let text = $(this).prev().prev().prev().val();
        navigator.clipboard.writeText(text);
    })
});
