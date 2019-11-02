class MyMap<T> {

    private map: {[key: string]: T} = {};
    
    setItem(key: string, item: T): void {
        this.map[key] = item;
    }

    getItem(key: string): T {
        return this.map[key];
    }

    clear(): void {
        this.map = {};
    }

    printMap(): void {
        for(let key in this.map) {
            console.log(key, this.map[key]);
        }
    }
}

const numberMap = new MyMap<number>();
numberMap.setItem('apples', 5);
numberMap.setItem('bananas', 10);
numberMap.printMap();
 
const stringMap = new MyMap<string>();
stringMap.setItem('name', "Max");
stringMap.setItem('age', "27");
stringMap.printMap();