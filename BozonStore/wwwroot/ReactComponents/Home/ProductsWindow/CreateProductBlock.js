import React from "react";


async function CreateProductBlock(props,setProductsBlocks) {
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

    let newProductBlock = await new Promise(resolve => {
        
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

    setProductsBlocks(prevProductsBlocks => [...prevProductsBlocks,newProductBlock]);
}

export default CreateProductBlock;