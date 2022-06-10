import React from 'react';
import { createRoot } from 'react-dom/client';
import styled from 'styled-components';

const ProductsWindow=async function(props){
    const target = document.getElementById(props.target);
    const targetRoot = createRoot(target);

    let response = await fetch("/Home/GetProducts/");

    let products = await response.json();

    products.forEach(function (product) {

        let mainImage = product.images.filter(function (image) {
            if (image.mainImage == true) {
                return image.name;
            }
        })[0].name;

        //alert(product.id + "/" + mainImage);

        fetch("/Common/GetProposalImage?prodId=" + product.id + "&imageName="+ mainImage)
            .then(response => response.blob())
            .then(blobFile => new File([blobFile], mainImage, { type: "image/*" }))
            .then(file => {
                let reader = new FileReader();
                reader.onload = function (event) {
                    targetRoot.render(
                        <div>
                            <img height="100px" src={event.target.result} ></img>
                        </div>);
                }
                reader.readAsDataURL(file);
            });
    });


    //<img width="100" src="@Url.Action(" GetImage","Common", new {path=" / Content / Ads / "+@prod.Id+" / "+@prod.Images.FirstOrDefault(i=>i.MainImage)?.Name, area="" })" />
    //targetRoot.render(<h3>ProductsWindow</h3>);
}

export default ProductsWindow; 
