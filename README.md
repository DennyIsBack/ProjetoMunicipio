# 🏛️ Projeto Município (WPF + EF Core + MVVM)

Aplicação desktop desenvolvida em C# com WPF que permite realizar consultas sobre municípios brasileiros.




## 💡 Funcionalidades

| Recurso | Descrição |
|--------|-----------|
| 🔍 Buscar por nome | Localiza um município exato pelo nome |
| 🧮 População por UF | Soma a população de todos os municípios da UF |
| 🏙️ Listar capitais | Mostra apenas as cidades marcadas como capital |
| 📊 Filtrar por população | Permite definir faixa mínima e/ou máxima |
| 🥇 Mais populosa ≠ capital | Para cada estado, exibe a cidade mais populosa se ela **não** for a capital |
| 🏆 Top 10 não capitais | Lista os 10 municípios mais populosos excluindo as capitais |

---


## 📐 Arquitetura

O projeto segue uma **arquitetura em camadas** baseada em princípios **SOLID**, utilizando os principais **Design Patterns** de aplicações corporativas

```
ProjetoMunicipio/
│
├── Controllers/
├── Data/
│ └── DAO/
├── DTOs/
├── Model/
├── Queries/
├── Repository/
├── Services/
├── Specifications/
├── ViewModels/
├── App.xaml
├── MainWindow.xaml
├── README.md
```

## 🧱 Camadas e Responsabilidades

### 📁 Controllers/
- `MunicipioController.cs`  
  Controlador para organização modular.

### 📁 Data/DAO/
- `MunicipioDAO.cs`  
  Responsável por acesso direto aos dados, sem lógica de negócio.
- `DbContext.cs`  
  Define o contexto do banco de dados.

### 📁 Model/
- `Municipio.cs`  
  Entidade que representa os municípios.

### 📁 Repository/
- `MunicipioRepository.cs`  
  Intermediário entre DAO e Service. Organiza e expõe dados prontos para uso de regras.

### 📁 Services/
- `MunicipioService.cs`  
  Contém as **regras de negócio** da aplicação:
  - Filtros

### 📁 DTOs/
- `MunicipioDTO.cs`  
  Projeção simplificada da entidade para a interface.
- `MunicipioPopulacaoResultadoDTO.cs`  
  DTO com total + lista para filtros populacionais.

### 📁 Specifications/
- `IPopulacaoSpecification.cs`  
  Interface para o padrão Specification.
- `PopulacaoRangeSpecification.cs`  
  Implementação de filtro por faixa populacional (mínimo/máximo).

### 📁 Queries/
- `MunicipioQueries.cs`  
  Contém métodos estáticos para projetar entidades `Municipio` em `MunicipioDTO`.

### 📁 ViewModels/
- `MainWindowViewModel.cs`  
  ViewModel principal do padrão **MVVM**, que expõe comandos e propriedades para a `MainWindow`.


## 🧠 Design Patterns Aplicados

| Padrão | Uso |
|--------|-----|
| **Repository** | `MunicipioRepository` entre DAO e Service |
| **Specification** | Filtro populacional com `PopulacaoRangeSpecification` |
| **DTO** | `MunicipioDTO`, `MunicipioPopulacaoResultadoDTO` |
| **Command (MVVM)** | `RelayCommand` no `MainWindowViewModel` |
| **Query Object** | `MunicipioQueries` para projeções limpas |


## 🧪 Princípios SOLID

- **SRP**: Cada classe com responsabilidade única
- **OCP**: Fácil de estender sem modificar o código central
- **LSP**: Implementação substituível (`Specification`)
- **ISP**: Interface `IPopulacaoSpecification` pequena e específica
- **DIP**: Services dependem de interfaces e repositórios, não de DAOs