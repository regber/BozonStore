window.onscroll = function () {
    AddProdsRow(4);
}

window.onresize = function () {
    AddProdsRow(4);
};

$(document).ready(function () {
    AddProdsRow(4);
});

function MustBeLoadedForSize()
{
    return (document.documentElement.scrollHeight * 0.98 < (document.documentElement.scrollTop + window.innerHeight));
}

function MustBeLoaded()
{
    var mustBe=false;

    if(MustBeLoadedForSize())
    {
        mustBe=true;
    }

    let productSearch = document.getElementById("ProductSearch");
    let productsWindow = document.getElementById("ProductsWindow");

    if(productSearch!=null)
    {
        if(productSearch.scrollHeight>=productsWindow.scrollHeight)
        {
            mustBe=true;
        }
    }


    return mustBe;
}

var BundleOnLoad = false;
var ProdBundle = null;
var BundleNumber = 0;

var ProdNumber = 0;

var ProdRunOut = false;

async function AddProdsRow(prodCountInRow) {
    
    if (!BundleOnLoad && !ProdRunOut) {
        BundleOnLoad = true;


        while (ProdRunOut == false && MustBeLoaded()) {


            for (let i = 0; i < prodCountInRow; i++) {


                if (ProdBundle == null || ProdNumber >= ProdBundle.length) {
                    ProdBundle = await GetProdBundle();

                    BundleNumber++;
                    ProdNumber = 0;
                }

                if (ProdBundle.length == 0) {
                    ProdRunOut = true;
                    break;
                }
                else {
                    AddProd(ProdBundle[ProdNumber]);
                    ProdNumber++;
                }
            }
        }

        BundleOnLoad = false;
    }
}

async function GetProdBundle() {

    let queryFilters = JSON.stringify(getQueryStringValues());
    
    let url = 'product/product/GetProdBunle?bundleNumber=' + BundleNumber + "&queryFilters=" + queryFilters
    let response;
    let jsonResponse;

    if (sessionStorage.getItem(url) == null) {
        response = await fetch(url);
        jsonResponse = await response.json()

        sessionStorage.setItem('ProdBundle', jsonResponse);

        return jsonResponse;
    }

    return sessionStorage.getItem("ProdBundle");
}

async function AddProd(prod) {

    CreateFromTemplate("#ProductsWindow", "#prodTemplate", { title: prod.title, price: prod.price, id: prod.id });

    let mainImageFile = await GetMainImage(prod);

    $("[id = '" + prod.id + "'].prodContainer .prodImage").attr("src", mainImageFile);
}

async function GetMainImage(prod) {

    let prodId = prod.id;
    let mainImageName = "";

    prod.images.forEach(function (image, index) {

        if (image.mainImage == true) {

            mainImageName = image.name;

        }
    });

    let url = "/Content/Proposal/" + prodId + "/" + mainImageName;

    return url;
}

function getQueryStringValues() {

    const queryObject = Object.create(null);
    
    var decodedUrl=decodeURI(window.location.href);
    var urlQuery = decodedUrl.slice(decodedUrl.indexOf('?') + 1).split('&');
    var regex = /\[[0-9]*\]/;

    for (var i = 0; i < urlQuery.length; i++) {

        var arrParamInfo = urlQuery[i].split('=');

        if (regex.test(arrParamInfo[0])) {
            var arrName = arrParamInfo[0].replace(regex, '');

            if (!Object.hasOwnProperty.bind(queryObject)(arrName)) {
                queryObject[arrName] = [];

            }
            queryObject[arrName].push(arrParamInfo[1]);
        }
        else {
            queryObject[arrParamInfo[0]] = arrParamInfo[1];
        }
    }

    return queryObject;
}