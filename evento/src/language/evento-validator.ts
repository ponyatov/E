import type { ValidationAcceptor, ValidationChecks } from 'langium';
import type { EventoAstType, Program } from './generated/ast.js';
import type { EventoServices } from './evento-module.js';

/**
 * Register custom validation checks.
 */
export function registerValidationChecks(services: EventoServices) {
    const registry = services.validation.ValidationRegistry;
    const validator = services.validation.EventoValidator;
    const checks: ValidationChecks<EventoAstType> = {
        // Person: validator.checkPersonStartsWithCapital
    };
    registry.register(checks, validator);
}

/**
 * Implementation of custom validations.
 */
export class EventoValidator {

    checkPersonStartsWithCapital(program: Program, accept: ValidationAcceptor): void {
        if (program.name) {
            const firstChar = program.name.substring(0, 1);
            if (firstChar.toUpperCase() !== firstChar) {
                accept('warning', 'program name should start with a capital.', { node: program, property: 'name' });
            }
        }
    }

}
