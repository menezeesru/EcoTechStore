// Cart Counter Management
function updateCartCount() {
    fetch('/api/cart/count')
        .then(response => response.json())
        .then(data => {
            const cartCountElement = document.getElementById('cartCount');
            if (cartCountElement) {
                cartCountElement.textContent = data.count;
                // Animar quando o número muda
                cartCountElement.classList.add('cart-count-updated');
                setTimeout(() => {
                    cartCountElement.classList.remove('cart-count-updated');
                }, 500);
            }
        })
        .catch(error => console.log('Error fetching cart count:', error));
}

// Atualizar contador quando a página carrega
document.addEventListener('DOMContentLoaded', function() {
    updateCartCount();
});

// Função para adicionar ao carrinho e atualizar contador
function addToCartAndUpdate(form) {
    form.addEventListener('submit', function(e) {
        // Aguardar um pouco antes de atualizar
        setTimeout(() => {
            updateCartCount();
        }, 100);
    });
}

// Aplicar a função a todos os formulários de adicionar ao carrinho
document.addEventListener('DOMContentLoaded', function() {
    const cartForms = document.querySelectorAll('.purchase-form, form[asp-page-handler="Add"]');
    cartForms.forEach(form => {
        addToCartAndUpdate(form);
    });
});
