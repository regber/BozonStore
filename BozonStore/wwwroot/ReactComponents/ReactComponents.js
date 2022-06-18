import React from 'react';
import ReactDOM from 'react-dom/client';
import ProductsWindow from './Home/ProductsWindow/ProductsWindow.jsx';
import SearchWindow from './Home/SearchWindow/SearchWindow';

let productsWindow =document.getElementById('ProductsWindow');
if(productsWindow!=null)
{
    const productsWindowRoot = ReactDOM.createRoot(productsWindowRoot);
    productsWindowRoot.render(<ProductsWindow/>);
}

let searchWindow =document.getElementById('SearchWindow');
if(searchWindow!=null)
{
    const searchWindowRoot = ReactDOM.createRoot(productsWindowRoot);
    searchWindowRoot.render(<SearchWindow/>);
}


//ProductsWindow({ target: "ProductsWindow" });