import type ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";

export class ToDoApiClient{
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "http://localhost:5173/";
        this.client = new ApiClientBase({
            baseUrl: this.baseUrl
        });

        this.todos =
    }
}