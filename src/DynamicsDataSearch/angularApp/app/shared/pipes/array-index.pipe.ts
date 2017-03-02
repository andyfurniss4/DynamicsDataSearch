import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'arrayIndex' })
export class ArrayIndexPipe implements PipeTransform {
    transform(value: number): number[] {
        let result: number[] = [];
        for (let i = 0; i < value; i++) {
            result.push(i);
        }
        return result;
    }
}