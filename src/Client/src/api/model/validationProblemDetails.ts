/**
 * Generated by orval v6.2.4 🍺
 * Do not edit manually.
 * Covid Test Management
 * OpenAPI spec version: 1.0
 */
import type { ValidationProblemDetailsErrors } from './validationProblemDetailsErrors';

export interface ValidationProblemDetails {
  type?: string | null;
  title?: string | null;
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  errors?: ValidationProblemDetailsErrors;
}
