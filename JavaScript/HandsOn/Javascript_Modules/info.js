import { add, sub, PI } from './math.js'
//access all components from the module
import * as MathUtils from './math.js'
console.log(add(10, 3))
console.log(sub(3443, 332));
console.log(PI);
console.log(MathUtils.add(2, 3))
console.log(MathUtils.sub(2, 3));
console.log(MathUtils.PI)