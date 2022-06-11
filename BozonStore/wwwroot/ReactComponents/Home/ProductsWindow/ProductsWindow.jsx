import React from 'react';
import { createRoot } from 'react-dom/client';
import styled from 'styled-components';

async function ProductBlock(props) {
    const { id, title, discription, price, shopid, images } = props;


    let mainImage = images.filter(function (image) {
        if (image.mainImage == true) {
            return image.name;
        }
    })[0].name;

    

    let file = await fetch("/Common/GetProposalImage?prodId=" + id + "&imageName="+ mainImage)
        .then(response => response.blob())
        .then(blobFile => new File([blobFile], mainImage, { type: "image/*" }))
        .then(file => {
            return file;
        });

    let result = await new Promise(resolve => {
        
        const reader = new FileReader();

        reader.onload = function(event) {
            let result = (
                <div onClick={()=>{window.location.href = "/Product/Product/ViewProduct?id=" + id;}} key={id} className='ProductBlock'>
                    <img className='ProductImg' height="100px" src={event.target.result} ></img>
                    <h3>{title}</h3>
                    <h3>Price:{price}</h3>
                </div>
            );

          resolve(result);
        };
        reader.readAsDataURL(file); 
      }); 

    return result;
}


 async function ProductsWindow(props){
    const target = document.getElementById(props.target);
    
    if(target!=null)
    {
        const targetRoot = createRoot(target);
        const ProductBlocks = []

        let response = await fetch("/Home/GetProducts/");
    
        let products = await response.json();

    
        products.forEach(function (product) {
    
            ProductBlock(product).then(prod => {
                renderBlock(prod);
            });
        });
    
          
        function renderBlock(prod){
            ProductBlocks.push(prod);
            targetRoot.render(
                <div id='ProductsBlocks'>
                    {
                        ProductBlocks.map(function(item,index){
                            return(item);
                        })
                    }
                </div>);
        }
    }
}

export default ProductsWindow; 
