function mask(object) {
    setTimeout(() => {
        let v = format(object.value)
        if (v != object.value) {
            object.value = v;
        }
    }, 1)
}

function format(value) {
    var r = value.replace(/\D/g, "")
    r = r.replace(/^0/, "")
    if (r.length > 11) {
        r = r.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
    } else if (r.length > 7) {
        r = r.replace(/^(\d\d)(\d{5})(\d{0,4}).*/, "($1) $2-$3");
    } else if (r.length > 2) {
        r = r.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
    } else if (v.trim() !== "") {
        r = r.replace(/^(\d*)/, "($1");
    }
    return r;
}