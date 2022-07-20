
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
    }).bind("set_text.jstree", function (objt, text) {
        console.log(text);

    }).bind("select_node.jstree", function (event, selected) {
        console.log(selected.node);
    });

});
