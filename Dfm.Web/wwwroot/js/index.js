
$(function () {

    $("#treePath").jstree({
        'core': {
            'data': {
                'url': '/home/getdata',
                'data': function (node) {
                    return { 'id': node.id };
                }
            }
        }
    }).bind("select_node.jstree", function (event, selected) {
        showContent(selected.node);
        updateBreadcrump(selected.node);        
    }).bind("loaded.jstree", function (event, selected) {
        var node = {
            id: "#",
            text: "#"
        };

        showContent(node);
        updateBreadcrump(node);    
    });
});

function showContent(node) {
    $("#show-content").empty();

    $.get("/home/getcontent", { id: node.id }, function (resp) {
        $.each(resp, function (key, val) {
            if (val.type !== "file") {                
                val.type = "folder";
            }

            $("#show-content").append(elementContent(val));
        });
    });
}

function elementContent(arg) {
    return '<li class="col mb-4" data-tags="' + arg.type +'" data-categories="files and folders">'
        + '<a class="d-block text-dark text-decoration-none" href="#">'
        + '<div class=text-center rounded">'
        + '<img src="/img/' + arg.type + '-96.png" alt="' + arg.type +'" /></div>'
        + '<div class="name text-muted text-decoration-none text-center pt-1">'+ arg.text +'</div>'
        + '</a></li>';
}

function updateBreadcrump(node) {
    $("#bread-crumb").empty();

    let arr = node.id.split('\\');
    $.each(arr, function (key, val) {
        var text = val == "" || val == "#" ? "Home" : val

        if (node.text === val) {
            $("#bread-crumb").append('<li class="breadcrumb-item active" aria-current="page">' + text +'</li>');
        } else {
            $("#bread-crumb").append('<li class="breadcrumb-item" style="color:#0d6efd">' + text +'</li>');
        }
    });
}

