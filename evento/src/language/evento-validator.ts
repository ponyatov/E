import type { ValidationAcceptor, ValidationChecks } from 'langium';
import { type ConstDef, type EventoAstType, type Program } from './generated/ast.js';
import type { EventoServices } from './evento-module.js';

/**
 * Register custom validation checks.
 */
export function registerValidationChecks(services: EventoServices) {
    const registry = services.validation.ValidationRegistry;
    const validator = services.validation.EventoValidator;
    const checks: ValidationChecks<EventoAstType> = {
        ConstDef: validator.checkPositive
        // Person: validator.checkPersonStartsWithCapital
    };
    registry.register(checks, validator);
}

/**
 * Implementation of custom validations.
 */
export class EventoValidator {

    checkPositive(cdef: ConstDef, accept: ValidationAcceptor): void {
        if (cdef.n) {
            if (cdef.n<=0)
                accept('warning', 'value must be positive.', { node: cdef, property: 'n' });
            if (cdef.n==0b1101)
                accept('error', 'bin ok', { node: cdef, property: 'n' });
        }
    }

    checkPersonStartsWithCapital(program: Program, accept: ValidationAcceptor): void {
        if (program.name) {
            const firstChar = program.name.substring(0, 1);
            if (firstChar.toUpperCase() !== firstChar) {
                accept('warning', 'program name should start with a capital.', { node: program, property: 'name' });
            }
        }
    }

}
