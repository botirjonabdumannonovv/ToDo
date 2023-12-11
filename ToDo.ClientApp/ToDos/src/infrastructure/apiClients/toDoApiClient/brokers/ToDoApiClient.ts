import type ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";
import {ToDoEndpointsDetails} from "@/infrastructure/apiClients/toDoApiClient/brokers/ToDoEndpointsDetails";

export class ToDoApiClient{
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "http://localhost:5173";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.todos = new ToDoEndpointsDetails(this.client);
    }

    public  todos: ToDoEndpointsDetails;
}