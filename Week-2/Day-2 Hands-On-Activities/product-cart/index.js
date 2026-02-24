import { products, generateInvoice } from './cartModule.js';

const invoice = generateInvoice(products);

console.log(invoice);