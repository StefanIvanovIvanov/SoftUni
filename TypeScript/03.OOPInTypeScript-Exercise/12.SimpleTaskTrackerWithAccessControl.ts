class Task {
    title: string;
    description: string;
    completed: boolean = false;
    private _createdBy!: string;

    constructor(title: string, description: string, craetedBy: string) {
        this.title = title;
        this.description = description;
        this._createdBy = craetedBy;
    }

    get createdBy() {
        return this._createdBy;
    }
    
    public toggleStatus(): void {
        this.completed = !this.completed;
    }

    public getDetails(): string {
        return `Task: ${this.title} - ${this.description} - ${this.completed ? 'Completed' : 'Pending'}`;
    }

    public static createSampleTasks(): Task[] {
        return [
            new Task('title', 'description', 'pesho'),
            new Task('another_title', 'another_description', 'pen40'),
        ]
    }
}

const task1 = new Task("Complete homework", "Finish math exercises", "Charlie");
task1.toggleStatus();
console.log(task1.getDetails());

const task2 = new Task("Clean room", "Clean the room", "Mary");
console.log(task2.getDetails());

 const tasks = Task.createSampleTasks();
 tasks.forEach(task => console.log(task.getDetails()));