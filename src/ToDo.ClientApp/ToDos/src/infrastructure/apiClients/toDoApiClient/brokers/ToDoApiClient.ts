import ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";
import {ToDoEndpointsDetails} from "@/infrastructure/apiClients/toDoApiClient/brokers/ToDoEndpointsDetails";

export class ToDoApiClient{
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7231/";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.todos = new ToDoEndpointsDetails(this.client);
    }

    public  todos: ToDoEndpointsDetails;
}