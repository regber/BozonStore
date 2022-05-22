function CreateFromTemplate(target,tmpltId,obj) {

    var body = $(target);
    var template = Handlebars.compile($(tmpltId).html());

    body.append(template(obj));
}