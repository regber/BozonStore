function AddProductToShopCart(e, url) {
    e.stopPropagation();
    fetch(url);
}