For proper formatting: open in Visual Studio Code and press Ctrl+Shift+V for preview.
Check console on project startup for correct URL. There will be 2 consoles open, one for normal presentation and one for API. Use the top url in the API console for calls.

# 📘 API Usage Guide

This document describes how to use the Movie & Book API built with ASP.NET Core. It includes authentication, available endpoints, and enhancements for validation, logging, and pagination.

---

## 🔐 Authentication

### Login Endpoint
```http
POST /api/auth/login
```
**Body:**
```json
{
  "username": "test",
  "password": "password"
}
```

**Response:**
```json
{
  "token": "<JWT token here>"
}
```

Use this token in the `Authorization` header for subsequent requests:
```http
Authorization: Bearer <token>
```

---

## 📚 Books Endpoints

### Get All Books (with Pagination)
```http
GET /api/books?page=1&pageSize=10

With different parameters:
GET /api/books?page=2&pageSize=5

```
Returns a paginated list of books.

### Add Book
```http
POST /api/books
Authorization: Bearer <token>
```
**Body:**
```json
{
  "title": "Example Book",
  "pages": 200,
  "isRead": true
}
```

### Get Total Read Books
```http
GET /api/books/read
Authorization: Bearer <token>
```

---

## 🎬 Movies Endpoints

### Get All Movies (with Pagination)
```http
GET /api/movies?page=1&pageSize=10
```
Returns a paginated list of movies.

### Add Movie
```http
POST /api/movies
Authorization: Bearer <token>
```
**Body:**
```json
{
  "title": "Example Movie",
  "duration": 120,
  "isWatched": true
}
```

### Get Total Watched Movies
```http
GET /api/movies/watched
Authorization: Bearer <token>
```

---