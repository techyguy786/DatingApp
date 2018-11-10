export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
}

// Result which comes after pagination
export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}
