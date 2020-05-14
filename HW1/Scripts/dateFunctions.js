
//date func 

function dateToFulldate(d) {
    let min = d.getMinutes()
    if (min < 10)
        return d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear() + "<br>" + (d.getHours()) + ":" + (d.getMinutes() + "0");
    else
        return d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear() + "<br>" + (d.getHours()) + ":" + (d.getMinutes())
}


function convertDate(dateToConvert) {
    let tempDate = new Date(0);
    tempDate.setUTCSeconds(dateToConvert);
    return tempDate;
}


function fixDate(date) {
    dateArr = date.split("-");
    return dateArr[2] + "/" + dateArr[1] + "/" + dateArr[0];
}

function calculateDuartion(time) {

    dateObj = new Date(time * 1000);
    hours = dateObj.getUTCHours();
    minutes = dateObj.getUTCMinutes();
    seconds = dateObj.getSeconds();

    return timeString = hours.toString().padStart(2, '0') + ':' + minutes.toString().padStart(2, '0') + ':' + seconds.toString().padStart(2, '0');


}