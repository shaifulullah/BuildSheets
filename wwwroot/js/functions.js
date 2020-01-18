var True = true;
var False = false;
function displayDiv(selectId, displayValue, displayId) {    // display a div based on a selected value in the dropdown list
    var dropdownValue = document.getElementById(selectId).selectedIndex;
    if (dropdownValue == displayValue) {
        document.getElementById(displayId).style.display = "contents";
    } else {
        document.getElementById(displayId).style.display = "none";
    }
} function actionConfirm(response) {
    // inherent browser popup to confirm an action    message = "Are you sure you want to ";
    message = message.concat(response);
    message = message.concat("?"); return confirm(message);
} function openInNewTab(id) {
    // open a link in a new tab in a browser
    var url = document.getElementById(id).value;
    var win = window.open(url, '_blank');
    win.focus();
} function displayDivWhenFilled() {
    // display a div when a text field has anything written, hide when empty    var newPartNumber = document.getElementById("NewPartNumber");
    var newPartNumberDescription = document.getElementById("NewPartNumberDescription");
    var info = newPartNumber.value; if (info != "") {
        newPartNumberDescription.style.display = "contents";
    } else {
        newPartNumberDescription.style.display = "none";
    }
}//Stop Default Action of Form Submission when Enter Key is Pressed
function stopRKey(evt) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
}
document.onkeypress = stopRKey; function popupAction(popupId, action) {
    var Id = "#" + popupId;
    if (action == "show") { $(Id).modal('show'); } else if (action == "hide") {
        $(Id).modal('hide');
    }
} function emailPopup() {
    popupAction("EmailPopup", "show");
    f();  // f() contains popupAction('EmailPopup', 'hide') after delay
} function validateFields(action) {
    var i = 0;
    var j = 0;
    var sibling;
    var elements = document.querySelectorAll("input, textarea, select");
    var validation = true; for (i = 0; i < elements.length; i++) {
        element = elements[i];
        if (element.dataset.validate == "yes") {
            var siblings = element.parentElement.childNodes; for (j = 0; j < siblings.length; j++) {
                sibling = siblings[j];
                if (sibling.nodeName == "TEXT") {
                    sibling.parentElement.removeChild(sibling);
                }
            }
            if (element.value.length == 0 || element.value == null) {
                element.parentElement.insertAdjacentHTML('beforeend',
                    "<text><span style = 'color:red'>This is a required field</span ></text>");
                validation = false;
            }
        }
    }
    if (validation == true) {
        if (action == "Reject") {
            popupAction('RejectOptions', 'show');
        } if (action == "Accept") {
            return confirm('Are you sure you want to ACCEPT?')
        } if (action == "Create") {
            return confirm('Are you sure you want to Create a Component Deviation?')
        }
    } else {
        return false;
    }
} function clearEmptyFields() {
    var elements = document.querySelectorAll("input, textarea"); for (var i = 0; i < elements.length; i++) {
        element = elements[i];
        if (element.value == "" || element.value == null) {
            parentDiv = element.parentElement;
            parentParentDiv = parentDiv.parentElement;
            parentParentDiv.removeChild(parentDiv);
        }
    }
} function GetMaxRows(tableId) {
    return $("#Sel_" + tableId + " :selected").val();
} function pagination(tableId) {
    var table = '#' + tableId;
    var pagination = $('.pagination.' + tableId);
    pagination.html('');
    var trnum = 0;
    var maxRows = GetMaxRows(tableId);
    var totalRows = $(table + ' tbody tr').length; $(table + ' > tbody > tr').each(function () {
        if (trnum < maxRows) {
            $(this).show();
        }
        else {
            $(this).hide();
        }
        trnum++;
    })
    if (totalRows > maxRows) {
        var pagenum = Math.ceil(totalRows / maxRows);
        for (var i = 1; i <= pagenum;) {
            pagination.append('<li data-page="' + i + '">\<span>' + i++
                + '<span class="sr-only">(current)</span></span>\</li>').show();
        }
    }
    $('.pagination.' + tableId + ' li:first-child').addClass('active');
    $('.pagination.' + tableId + ' li').on('click', function () {
        var pageNum = $(this).attr('data-page');
        var trIndex = 0;
        $('.' + tableId + ' li').removeClass('active')
        $(this).addClass('active')
        $(table + '> tbody > tr').each(function () {
            if (trIndex >= (maxRows * pageNum) || trIndex < ((maxRows * pageNum) - maxRows)) {
                $(this).hide();
            } else {
                $(this).show();
            }
            trIndex++;
        })
    })
}
// function for Attaching Files Feature
//function fileUpload(filename) {
//    var inputfile = document.getElementById(filename);
//    var files = inputfile.files;
//    var fdata = new FormData();
//    for (var i = 0; i != files.length; i++) {
//        fdata.append("files", files[i]);
//    }
//    $.ajax(
//        {
//            url:"/ComponentDeviation/Create",
//            data: fdata,
//            processData: false,
//            contentType: false,
//            type: "POST",
//            success: function (data)
//            {
//                //alert("File uploaded successfully");
//            },
//            error: function (data) {
//                //alert("File upload FAIL");//            }                   
//        }
//    )
//}async function f() {
let promise = new Promise((resolve, reject) => {
    setTimeout(() => resolve("done!"), 3000)
}); let result = await promise; // wait till the promise resolves (*)
// HIDE ACTION
popupAction('EmailPopup', 'hide');
}function CallDetails(id) {
    window.location = "Details/" + id;
}
$('document').ready(function () {    //$('.table').DataTable();
    //$('.SelectControl').select2({    //    placeholder: "Select Item",    //    allowClear: true    //});    jQuery('[data-confirm]').click(function (e) {
    if (!confirm(jQuery(this).attr("data-confirm"))) {
        e.preventDefault();
    }
});
$(':disabled').css("backgroundColor", "transparent")//.css("cursor", "default")//.css("backgroundColor", "#f9f9f9");    $(".InputSearchField").on("focus", function () {
$(this).animate({
    width: "+=50px"
}, 500);
    });
$(".InputSearchField").on("blur", function () {
    $(this).animate({
        width: "-=50px"
    }, 500);
});
$('dl dt').addClass('geotab-gradient')    $('form').bind('submit', function () {
    $(this).find('input').prop('disabled', false);
    $(this).find('select').prop('disabled', false);
}); $('.navbar-toggle').click(function () {
    if ($('.navbar-collapse').hasClass('in')) {
        $('.navbar-collapse').slideUp("slow");
        $('.navbar-collapse').removeClass('in');
    }
    else {
        $('.navbar-collapse').slideDown("slow");
        $('.navbar-collapse').addClass('in');
    }
}); $('.MaxRowSelect').on("change", function () {
    pagination($(this).attr("name"));
}); $('#clearFiltersSearch').click(function () {
    $('#SearchForm select').each(function (index) {
        this.selectedIndex = 0;
    });
    $('#SearchForm input').each(function (index) {
        $(this).val('');
    });
});
$("#btnRejectValidation").click(function () {
    $("#Status option").removeAttr("selected");
    $("#Status option[value='RejectedValidation']").attr("selected", "selected")
})
$("#btnApproveValidation").click(function () {
    $("#Status option").removeAttr("selected");
    $("#Status option[value='AwaitingApproval']").attr("selected", "selected")
})
$("#btnReject").click(function () {
    $("#Status option").removeAttr("selected");
    $("#Status option[value='RejectedApproval']").attr("selected", "selected")
})
$("#btnApprove").click(function () {
    $("#Status option").removeAttr("selected");
    $("#Status option[value='Approved']").attr("selected", "selected")
})
$("#btnSubmitValidation").click(function () {
    $("#Status option").removeAttr("selected");
    $("#Status option[value='AwaitingValidation']").attr("selected", "selected")
})    $('#LinkUrls option').attr("selected", "true");
$('#URLText').keypress(function (event) {
    var url = "";
    if (event.which == 13) {
        event.preventDefault();
        url = $("#URLText").val();
        if (url != "") {
            if (!url.match(/^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/gim)) {
                $("#urlValidation").text("This link is not a valid url. It should follow this pattern: https://www.example.com");
            }
            else {
                $("#urlValidation").text("");
                var option = new Option(url, url, true, true);
                $('#LinkUrls').append(option);
                $('#btnSubmit').show();
                $('#URLRepresentation').append("<li class='form-control'>" +
                    "<span onclick = 'editUrl(this)'>" + url + "</span > " +
                    "<i class='glyphicon glyphicon-remove' onclick='removeUrl(this)'></i >" +
                    "</li> ")
                $("#URLText").val("");
            }
        }
    }
    $('#LinkUrls option').attr("selected", "true");
})
}) var isEqual = function (value, other) {    // Get the value type
    var type = Object.prototype.toString.call(value);    // If the two objects are not the same type, return false
    if (type !== Object.prototype.toString.call(other)) return false;    // If items are not an object or array, return false
    if (['[object Array]', '[object Object]'].indexOf(type) < 0) return false;    // Compare the length of the length of the two items
    var valueLen = type === '[object Array]' ? value.length : Object.keys(value).length;
    var otherLen = type === '[object Array]' ? other.length : Object.keys(other).length;
    if (valueLen !== otherLen) return false;    // Compare two items
    var compare = function (item1, item2) {        // Get the object type
        var itemType = Object.prototype.toString.call(item1);        // If an object or array, compare recursively
        if (['[object Array]', '[object Object]'].indexOf(itemType) >= 0) {
            if (!isEqual(item1, item2)) return false;
        }        // Otherwise, do a simple comparison
        else {            // If the two items are not the same type, return false
            if (itemType !== Object.prototype.toString.call(item2)) return false;            // Else if it's a function, convert to a string and compare
            // Otherwise, just compare
            if (itemType === '[object Function]') {
                if (item1.toString() !== item2.toString()) return false;
            } else {
                if (item1 !== item2) return false;
            }
        }
    };    // Compare properties
    if (type === '[object Array]') {
        for (var i = 0; i < valueLen; i++) {
            if (compare(value[i], other[i]) === false) return false;
        }
    } else {
        for (var key in value) {
            if (value.hasOwnProperty(key)) {
                if (compare(value[key], other[key]) === false) return false;
            }
        }
    }    // If nothing failed, return true
    return true;
}; function removeUrl(element) {
    var li = $(element).parent();
    var span = $(element).prev();
    var spanText = span.text().trim();
    li.remove();
    $('#LinkUrls option[value="' + spanText + '"]').remove();
    $('#btnSubmit').show();
    hideNewLinks();
} function hideNewLinks() {
    if ($("#URLRepresentation").children().length > 0) {
        $('#newLinks').removeAttr("hidden");
    }
    else {
        $('#newLinks').attr("hidden", true);
    }
    compareCurrentValues();
}