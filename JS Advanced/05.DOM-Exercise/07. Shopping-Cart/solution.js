function solve() {
   let productNames = [];
   let productPrices = [];
   let shoppingCart = document.getElementsByClassName('shopping-cart')[0];
   const textArea = document.getElementsByTagName('textarea')[0];
   shoppingCart.addEventListener('click', AddToCart);

   let checkOut = document.getElementsByClassName('checkout')[0];
   checkOut.addEventListener('click', CheckOut);

   function AddToCart(e) {
      let targetedProduct = e.target;
      // console.log(targetedProduct)

      let productDiv = targetedProduct.parentNode;
      // console.log(productDiv);

      let product = productDiv.parentNode;
      // console.log(product);
      let name = product.children[1].getElementsByClassName('product-title')[0].textContent;
      // console.log(name);

      let price = Number(product.children[3].textContent);
      // console.log(price)
      productNames.push(name);
      productPrices.push(price);
      let addedProducts = `Added ${name} for ${price} to the cart.\n`
      textArea.value += addedProducts;
   }

   function CheckOut() {
      let joinedNames = productNames.filter(unique);
      //console.log(productNames.join(', '));
      let summedPrice = productPrices.reduce((a, b) => a + b, 0);
      //console.log(summedPrice);
      let checkedOutProducts = `You bought ${joinedNames} for ${summedPrice}.`
      textArea.value += checkedOutProducts;

      shoppingCart.removeEventListener('click', AddToCart);
   }
}

const unique = (value, index, self) => {
   return self.indexOf(value) === index
}