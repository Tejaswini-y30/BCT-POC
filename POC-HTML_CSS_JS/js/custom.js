function compare() {
    var min = parseInt(document.getElementById("leftinput").value);
    var max = parseInt(document.getElementById("rightinput").value);

    if(min==0 || max==0){
        alert("value cannot be zero");
        document.getElementById('rightinput').value = '';
    }


    if (min === max) {
        alert("Value cannot be same");
        document.getElementById('rightinput').value = '';
    }
    if (min > max) {
        alert("Min value cannot be greater than max value");
        document.getElementById('rightinput').value = '';
        document.getElementById('leftinput').value = '';
    }

};

