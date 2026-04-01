# API Plan

> Early-stage planning document. Versioned under `/api/v1/`.

---

## Auth

| Method | URL | Request Body | Response | Description |
|--------|-----|-------------|----------|-------------|
| `POST` | `/api/v1/auth/register` | `{ userName, password }` | `{ userId, userName, accountCreated }` | Register a new user |
| `POST` | `/api/v1/auth/login` | `{ userName, password }` | `{ token, userId }` | Log in and receive a JWT |
| `POST` | `/api/v1/auth/logout` | — | `{ success: true }` | Invalidate the current session/token |
| `POST` | `/api/v1/auth/password-reset/request` | `{ userName }` | `{ success: true }` | Generate a password reset token and send it |
| `POST` | `/api/v1/auth/password-reset/confirm` | `{ token, newPassword }` | `{ success: true }` | Validate token and update password |

---

## Users

| Method | URL | Request Body | Response | Description |
|--------|-----|-------------|----------|-------------|
| `GET` | `/api/v1/users/{userId}` | — | `{ userId, userName, accountCreated, lastLogin, admin }` | Get a user's profile |
| `PATCH` | `/api/v1/users/{userId}` | `{ userName?, password? }` | `{ userId, userName }` | Update a user's profile |
| `DELETE` | `/api/v1/users/{userId}` | — | `{ success: true }` | Hard delete user and all associated data |

---

## View Permissions

| Method | URL | Request Body | Response | Description |
|--------|-----|-------------|----------|-------------|
| `GET` | `/api/v1/users/{userId}/permissions` | — | `[{ userId }]` | Get all users that can view this user's data |
| `POST` | `/api/v1/users/{userId}/permissions` | `{ targetUserId }` | `{ success: true }` | Grant another user view access |
| `DELETE` | `/api/v1/users/{userId}/permissions/{targetUserId}` | — | `{ success: true }` | Revoke a user's view access |

---

## Transactions

| Method | URL | Request Body | Response | Description |
|--------|-----|-------------|----------|-------------|
| `GET` | `/api/v1/users/{userId}/transactions` | — | `[{ transactionId, recipientId, amount, direction, date, categories }]` | Get all transactions for a user |
| `POST` | `/api/v1/transactions` | `{ userId, recipientId, amount, direction, date, categoryIds[] }` | `{ transactionId, ... }` | Create a new transaction |
| `PATCH` | `/api/v1/transactions/{transactionId}` | `{ recipientId?, amount?, direction?, date?, categoryIds[]? }` | `{ transactionId, ... }` | Update a transaction |
| `DELETE` | `/api/v1/transactions/{transactionId}` | — | `{ success: true }` | Delete a transaction |

---

## Recipients

| Method | URL | Request Body | Response | Description |
|--------|-----|-------------|----------|-------------|
| `GET` | `/api/v1/users/{userId}/recipients` | — | `[{ recipientId, name, suggestedCategoryId }]` | Get all recipients for a user (plus globals) |
| `POST` | `/api/v1/recipients` | `{ name, suggestedCategoryId?, userId? }` | `{ recipientId, name }` | Create a new recipient |
| `PATCH` | `/api/v1/recipients/{recipientId}` | `{ name?, suggestedCategoryId? }` | `{ recipientId, name }` | Update a recipient |
| `DELETE` | `/api/v1/recipients/{recipientId}` | — | `{ success: true }` | Delete a recipient |

---

## Categories

| Method | URL | Request Body | Response | Description |
|--------|-----|-------------|----------|-------------|
| `GET` | `/api/v1/users/{userId}/categories` | — | `[{ categoryId, categoryName, categoryColour, budget }]` | Get all categories for a user (plus globals) |
| `POST` | `/api/v1/categories` | `{ categoryName, categoryColour, budget?, userId? }` | `{ categoryId, ... }` | Create a new category |
| `PATCH` | `/api/v1/categories/{categoryId}` | `{ categoryName?, categoryColour?, budget? }` | `{ categoryId, ... }` | Update a category |
| `DELETE` | `/api/v1/categories/{categoryId}` | — | `{ success: true }` | Delete a category |

---

## Admin

| Method | URL | Request Body | Response | Description |
|--------|-----|-------------|----------|-------------|
| `GET` | `/api/v1/admin/users` | — | `[{ userId, userName, accountCreated, lastLogin }]` | Get all users (admin only) |
| `DELETE` | `/api/v1/admin/users/{userId}` | — | `{ success: true }` | Admin hard delete of a user |
