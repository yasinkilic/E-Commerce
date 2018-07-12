//Search Area//
var input = document.getElementById("srcinput");
var span = document.getElementById("srcspan");
var a = input.innerText;
var sonuc = document.getElementById("sonuc");
var close = document.getElementById("close");
function InputVisible() {
    input.style.visibility = "visible";
    close.style.visibility = "visible";
}
function InputHidden() {
    input.style.visibility = "hidden";
    close.style.visibility = "hidden";
    sonuc.innerHTML = "";
}

function ShowResults(a) {
    document.getElementById("sonuc").innerHTML = "";
    if (a.keyCode != 13 && a.keyCode != 37 && a.keyCode != 39 && a.keyCode != 8) {
        if (a.length) {

            $.ajax({
                url: "/Function/Search/?a=" + a,
                type: "POST",
                success: function (e) {
                    for (var i in e) {
                        var li = '<li class="litems"><a class="litemlink" href="/Home/Details/' + e[i].ID + '"><img src="' + e[i].ImagePath + '" class="aramaimg"/>' + e[i].ProductName + '</a></li>';
                        $("#sonuc").append(li);
                    }
                }

            })

        }
    }
}
//Search Area1//
var input1 = document.getElementById("srcinput1");
var span1 = document.getElementById("srcspan1");
var a1 = input1.innerText;
var sonuc1 = document.getElementById("sonuc1");
var close1 = document.getElementById("close1");
function InputVisible1() {
    input1.style.visibility = "visible";
    close1.style.visibility = "visible";
}
function InputHidden1() {
    input1.style.visibility = "hidden";
    close1.style.visibility = "hidden";
    sonuc1.innerHTML = "";
}

function ShowResults1(e) {
    
    if (a.keyCode != 13 && a.keyCode != 37 && a.keyCode != 39 && a.keyCode != 8) {

        $.ajax({
            url: "/Function/Search/?a="+a,
            type: "POST",
            success: function(e) {
                for (var i in e) {
                    var li = '<li class="litems"><a href="/Home/Details/' + e[i].ID + '" style="width:auto;"><img src="' + e[i].ImagePath + '" class="aramaimg"/>' + e[i].ProductName + '</a></li>';
                    $("#sonuc1").append(li);
                }
            }

        })

    }

}
//Kutu Secim//
var kutu, gul, cekmeceurun;
function GetImage(id) {
    var path;
    switch (parseInt(id)) {
        case 1:
            path = "/Content/Images/DBeyazKutu.jpg";
            kutu = "Dikdörtgen Beyaz Kutu ";
            break;
        case 2:
            path = "/Content/Images/DSariKutu.jpg";
            kutu = "Dikdörtgen Sarı Kutu ";
            break;
        case 3:
            path = "/Content/Images/YBeyazKutu.jpg";
            kutu="Yuvarlak Beyaz Kutu "
            break;
  
        default:
            path = "/Content/Images/DBeyazKutu.jpg";
            kutu = "Dikdörtgen Beyaz Kutu ";
            break;
    }
    document.getElementById("secilen").setAttribute("src", path);
  
}

function Onay(id) {
    var wrap1 = document.getElementById("wrap1");
    var wrap2 = document.getElementById("wrap2");
    var wrap3 = document.getElementById("wrap3");
    var wrap4 = document.getElementById("wrap4");
    switch (parseInt(id)) {
        case 10:
            wrap1.style.display = "none";
            wrap2.style.display = "grid";
            break;
        case 11:
            wrap2.style.display = "none";
            wrap3.style.display = "grid";
            break;
        case 12:
            wrap3.style.display = "none";
            UrunuGetir();
            wrap4.style.display = "grid";
           
            break;
    }
}
function UrunuGetir() {
    var wrap4 = document.getElementById("wrap4");
        var data = kutu + gul + cekmeceurun;
        $.ajax({
            url: "/Function/SiparisTasarimSonucu/?dt=" + data,
            data: data,
            type: "post",
            success: function (e) {
                var sonuc = '<img id="tasarimsonuc" class="img-responsive" src="' + e.ImagePath + '"/>';
                $("#wrap4").append(sonuc);
            }
        })
}
function GetImage1(id) {
    var path;
    switch (parseInt(id)) {
        case 4:
            path = "/Content/Images/Beyaz.jpg";
            gul="Beyaz Gül ve "
            break;
        case 5:
            path = "/Content/Images/Lila.jpg";
            gul = "Lila ve ";
            break;
        case 6:
            path = "/Content/Images/Kirmizi.jpg";
            gul = "Kırmızı Gül ve ";
            break;
    }
    document.getElementById("secilen1").setAttribute("src", path);
}
function GetImage2(id) {
    var path;
    switch (parseInt(id)) {
        case 7:
            path = "/Content/Images/Jelibon.jpg";
            cekmeceurun="Jelibonlu"
            break;
        case 8:
            path = "/Content/Images/Makaron.jpg";
            cekmeceurun = "Makaronlu";
            break;
        default:
            path = "/Content/Images/Makaron.jpg";
            cekmeceurun = "Makaronlu";
            break;
    }
    document.getElementById("secilen2").setAttribute("src", path);
}
//Kutu Secim Bitti//
