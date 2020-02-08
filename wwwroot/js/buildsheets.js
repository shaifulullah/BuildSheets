var names = [];
$(function () {
    $(".selectList").select2({
        placeholder: 'Select an Option',
        width: 'element',
        allowClear: true
    });
})
$('document').ready(function () {
    var elements = document.getElementsByClassName("linkSpan");
    $(elements).each(function (e, element) {
        names.push($(element).attr("name")) //push the name to the array if it already exists
    })
    $(".btn.glyphicon").each(function myfunction(i, el) { //function to revert the remove icon
        if ($(el).hasClass("glyphicon-remove")) {
            $(el).toggleClass("glyphicon-remove glyphicon-ok")
        }
    })
    $('#hwQuantity').keypress(function (event) {
        if (event.which == 13) {
            event.preventDefault();
            setNameandQuantity("#hwValidationMsg", "#hwName", "#hwQuantity", "#hwRepresentation", "OtherHardwaresDictonary")
        }
    })
    $('#insertQuantity').keypress(function (event) {
        if (event.which == 13) {
            event.preventDefault();
            setNameandQuantity("#insertValidationMsg", "#insertName", "#insertQuantity", "#insertRepresentation", "InsertsDictonary")
        }
    })
    $('#labelQuantity').keypress(function (event) {
        if (event.which == 13) {
            event.preventDefault();
            setNameandQuantity("#labelValidationMsg", "#labelName", "#labelQuantity", "#labelRepresentation", "LabelsDictonary")
        }
    })
    $('#PackagingQuantity').keypress(function (event) {
        if (event.which == 13) {
            event.preventDefault();
            setNameandQuantity("#PackagingValidationMsg", "#PackagingName", "#PackagingQuantity", "#PackagingRepresentation", "PackagingsDictonary")
        }
    })
    function setNameandQuantity(validationMessage, name, quantity, representation, postMethodDictionary) {
        var inputQuantity = "";
        inputQuantity = $(quantity).val(); //get the val
        if (inputQuantity != "") {
            if (!inputQuantity.match(/^[0-9](\/.*)?$/)) { //check if quantity is in valid format
                $(validationMessage).text("This quantity is not in valid format. Quantity should be a whole number or a fraction of it, example: 123 or 1/2");
            }
            else {
                var name = $(name).val(); //get the name of the hardware
                if (name != null && name != "") {
                    var nameExists = names.find(function (e) {
                        return e == name
                    })
                    if (nameExists == undefined) { //if the name is not in the array
                        $(validationMessage).text("");
                        var input = document.createElement('input'); //create an input that will be in the POST
                        input.name = postMethodDictionary + "[" + name + "]" //dictonary of names and quantity
                        input.value = inputQuantity; //the value that will be sent
                        input.type = "hidden" //don't show the input                        
                        var listItem = document.createElement('li'); //create the list item
                        listItem.className = "list-group-item"; //add class                        
                        var spanText = document.createElement('span'); //create the span
                        spanText.textContent = " : " + name; //add the link name to it                        
                        var anchor = document.createElement("span"); //create the anchor
                        anchor.textContent = inputQuantity; //the text of it
                        var i = document.createElement('i'); //X icon
                        i.className = "glyphicon glyphicon-remove" //glyphicon-remove == X
                        i.setAttribute('onclick', 'removeInput(this)') //onclick to call the removeinput                        
                        listItem.append(anchor);
                        listItem.append(spanText); //append the elements to the listitem
                        listItem.append(i);
                        listItem.append(input); $(representation).append(listItem); //append the listitem
                        names.push(name); //add the name to the array
                        $(quantity).val("");
                        $(name).val("");
                    }
                    else {
                        $(validationMessage).text("A hardware with this Name has already been added."); //message to the user
                    }
                }
                else {
                    $(validationMessage).text("Hardware name cannot be empty."); //message to the user
                }
            }
        }
    }
})
function removeInput(element) { //function called when the X is clicked
    var li = $(element).parent(); //get the list item
    var span = $(element).prev(); //get the span
    var spanText = span.text().trim();
    var found = names.indexOf(spanText); //find the name in the array of names
    names.splice(found, 1); // remove the name
    li.remove(); //remove the list item from the list
}