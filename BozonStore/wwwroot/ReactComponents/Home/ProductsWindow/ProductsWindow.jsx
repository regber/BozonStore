import React from 'react';
import { createRoot } from 'react-dom/client';
import styled from 'styled-components';
import CreateProductBlock from './CreateProductBlock'

    function ProductsWindow(){

        const [productsBlocks, setProductsBlocks] = React.useState([])

        async function loadProducts() {
            let response =await fetch("/Home/GetProducts/");
    
            let products = await response.json();
            
            products.forEach(function (product) {
                CreateProductBlock(product,setProductsBlocks);
            });
        }
        
        React.useEffect(()=>{loadProducts();},[]);
    
        return (
            <div id='ProductsBlocks'>
                {
                    productsBlocks.map(function(item,index){
                        return item;
                    })
                }
            </div>
        );
    }

export default ProductsWindow; 
