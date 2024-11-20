using Peiton.Contracts.Seguimientos;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Seguimientos;

[Injectable]
public class GuardarTareasSeguimientoHandler(ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, TareaAgendaViewModel[] request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tutelado no encontrado");

        var tareas = tutelado.TareasAgenda.ToArray();

        for (var i = 0; i < request.Length; i++)
        {
            TareaAgenda tarea;
            var vm = request[i];
            if (tareas.Length > i)
            {
                tarea = tareas[i];
            }
            else
            {
                tarea = new TareaAgenda();
                tutelado.TareasAgenda.Add(tarea);
            }

            tarea.Orden = i + 1;
            tarea.Completado = vm.Completado;
            tarea.Descripcion = vm.Descripcion;
        }

        for (var i = request.Length; i < tareas.Length; i++)
        {
            tutelado.TareasAgenda.Remove(tareas[i]);
        }

        await unitOfWork.SaveChangesAsync();
    }
}