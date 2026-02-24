 
export const products = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 1000, quantity: 2 },
    { name: "Keyboard", price: 2000, quantity: 1 },
    { name: "Headphones", price: 3000, quantity: 1 }
];

 
export const calculateTotal = (items) =>
    items.reduce((total, product) =>
        total + (product.price * product.quantity), 0
    );

 
export const generateInvoice = (items) => {

     
    const invoiceLines = items.map(product =>
        `${product.name} 
        Price: ₹${product.price} 
        Qty: ${product.quantity} 
        Subtotal: ₹${product.price * product.quantity}`
    ).join("\n------------------------\n");

    const totalAmount = calculateTotal(items);

    return `
=========== INVOICE ===========

${invoiceLines}

------------------------
TOTAL AMOUNT: ₹${totalAmount}

================================
`;
};