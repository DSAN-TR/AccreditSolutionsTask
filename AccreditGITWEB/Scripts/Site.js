$(document).ready(function () {

    function ClearView() {
        ContentClear($('#userContent'));
        ContentClear($('#repoContent'));
    }

    $('#btnSubmit').click(function () {

        ClearView();

        EmptyStringValidation($('#username'), "Username");

        var postdata = {
            uservm: {
                username: $('#username').val()
            }
        };


        $('#userContent').html(RenderLoading());

        $.ajax({
            type: 'POST',
            url: '/Home/PostUser',
            async: true,
            data: postdata,
            dataType: 'html',
            success: function (result) {

                if (StringIsNullOrEmpty(result)) {
                    $('#userContent').html("<p>User not found!!</p>");
                    return;
                }

                $('#userContent').html(result);

                var url = $('#hdnrepo').val();
                if (StringIsNullOrEmpty(url)) {
                    $('#repoContent').html("<p>Repository not found!!</p>");
                    return;
                }

                $('#repoContent').html(RenderLoading());
                LoadRepos(url);


            }, error: function (xhr, status) {
                ContentClear($('#userContent'));
                console.warn(status);
            }

        });
    });

    function LoadRepos(url) {
        $.ajax({
            url: '/Home/GetRepos?repoUrl=' + url,
            contentType: 'application/html; charset=utf-8',
            async: true,
            type: 'GET',
            dataType: 'html',
            success: function (result) {
                if (StringIsNullOrEmpty(result)) {
                    $('#repoContent').html("<p>Repository not found!!</p>");
                    return;
                }

                $('#repoContent').html(result);
            }, error: function (xhr, status) {
                ContentClear($('#repoContent'));
                console.warn(status);
            }
        });
    }

});