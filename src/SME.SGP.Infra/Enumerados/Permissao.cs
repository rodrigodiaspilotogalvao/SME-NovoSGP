﻿namespace SME.SGP.Infra
{
    public enum Permissao
    {
        /*Retirar comentário após a implementação dos menus*/
        [PermissaoMenu(Menu = "Sondagem", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, Url = "/sondagem", EhConsulta = true)]
        S_C = 5,

        [PermissaoMenu(Menu = "Boletim", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 4, Url = "/relatorios/diario-classe/boletim-simples", EhConsulta = true)]
        B_C = 9,

        [PermissaoMenu(Menu = "Calendário Escolar", Icone = "fas fa-calendar-alt", IconeDashBoard = "far fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 1, Url = "/calendario-escolar", EhConsulta = true)]
        C_C = 10,

        [PermissaoMenu(Menu = "Calendário Escolar", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 1, Url = "/calendario-escolar", EhInclusao = true)]
        C_I = 11,

        [PermissaoMenu(Menu = "Calendário Escolar", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 1, Url = "/calendario-escolar", EhExclusao = true)]
        C_E = 12,

        [PermissaoMenu(Menu = "Calendário Escolar", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 1, Url = "/calendario-escolar", EhAlteracao = true)]
        C_A = 13,

        [PermissaoMenu(Menu = "Plano de aula/Frequência", Icone = "fas fa-book-reader", EhMenu = false, EhAlteracao = true)]
        F_A = 17,

        [PermissaoMenu(Menu = "Atribuição de CJ", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 2, EhConsulta = true, Url = "/gestao/atribuicao-cjs")]
        ACJ_C = 18,

        [PermissaoMenu(Menu = "Atribuição de CJ", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 2, EhInclusao = true, Url = "/gestao/atribuicao-cjs/editar")]
        ACJ_I = 19,

        [PermissaoMenu(Menu = "Atribuição de CJ", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 2, EhExclusao = true, Url = "/gestao/atribuicao-cjs/editar")]
        ACJ_E = 20,

        [PermissaoMenu(Menu = "Atribuição de CJ", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 2, EhAlteracao = true, Url = "/gestao/atribuicao-cjs/editar")]
        ACJ_A = 21,

        [PermissaoMenu(Menu = "Comunicados", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 6, EhConsulta = true, Url = "/gestao/comunicados")]
        CO_C = 140,

        [PermissaoMenu(Menu = "Comunicados", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 6, EhExclusao = true, Url = "/gestao/comunicados")]
        CO_E = 142,

        [PermissaoMenu(Menu = "Comunicados", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 6, EhAlteracao = true, Url = "/gestao/comunicados/novo")]
        CO_A = 143,

        [PermissaoMenu(Menu = "Comunicados", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 6, EhInclusao = true, Url = "/gestao/comunicados/novo")]
        CO_I = 141,

        [PermissaoMenu(Menu = "Notas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhConsulta = true, Url = "/diario-classe/notas")]
        NC_C = 22,

        [PermissaoMenu(Menu = "Notas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhInclusao = true, Url = "/diario-classe/notas")]
        NC_I = 23,

        [PermissaoMenu(Menu = "Notas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhExclusao = true, Url = "/diario-classe/notas")]
        NC_E = 24,

        [PermissaoMenu(Menu = "Notas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhAlteracao = true, Url = "/diario-classe/notas")]
        NC_A = 25,

        [PermissaoMenu(Menu = "Plano Anual", Icone = "fas fa-list-alt", IconeDashBoard = "far fa-calendar-minus", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, Url = "/planejamento/plano-anual", EhConsulta = true)]
        PA_C = 26,

        [PermissaoMenu(Menu = "Plano Anual", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, Url = "/planejamento/plano-anual", EhInclusao = true)]
        PA_I = 27,

        [PermissaoMenu(Menu = "Plano Anual", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, Url = "/planejamento/plano-anual", EhExclusao = true)]
        PA_E = 28,

        [PermissaoMenu(Menu = "Plano Anual", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, Url = "/planejamento/plano-anual", EhAlteracao = true)]
        PA_A = 29,

        [PermissaoMenu(Menu = "Frequência/Plano de aula", Icone = "fas fa-book-reader", IconeDashBoard = "far fa-check-square", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 1, EhConsulta = true, Url = "/diario-classe/frequencia-plano-aula")]
        PDA_C = 30,

        [PermissaoMenu(Menu = "Frequência/Plano de aula", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 1, EhInclusao = true, Url = "/diario-classe/frequencia-plano-aula")]
        PDA_I = 31,

        [PermissaoMenu(Menu = "Frequência/Plano de aula", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 1, EhExclusao = true, Url = "/diario-classe/frequencia-plano-aula")]
        PDA_E = 32,

        [PermissaoMenu(Menu = "Frequência/Plano de aula", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 1, EhAlteracao = true, Url = "/diario-classe/frequencia-plano-aula")]
        PDA_A = 33,

        [PermissaoMenu(Menu = "Plano de Ciclo", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 1, Url = "/planejamento/plano-ciclo", EhConsulta = true)]
        PDC_C = 34,

        [PermissaoMenu(Menu = "Plano de Ciclo", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 1, Url = "/planejamento/plano-ciclo", EhInclusao = true)]
        PDC_I = 35,

        [PermissaoMenu(Menu = "Plano de Ciclo", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 1, Url = "/planejamento/plano-ciclo", EhExclusao = true)]
        PDC_E = 36,

        [PermissaoMenu(Menu = "Plano de Ciclo", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 1, Url = "/planejamento/plano-ciclo", EhAlteracao = true)]
        PDC_A = 37,

        [PermissaoMenu(EhMenu = false, EhConsulta = true, Menu = "Notificação", Agrupamento = "Notificação", Url = "/notificacoes")]
        N_C = 38,

        [PermissaoMenu(EhMenu = false, EhInclusao = true, Menu = "Notificação", Agrupamento = "Notificação", Url = "/notificacoes")]
        N_I = 39,

        [PermissaoMenu(EhMenu = false, EhExclusao = true, Menu = "Notificação", Agrupamento = "Notificação", Url = "/notificacoes")]
        N_E = 40,

        [PermissaoMenu(EhMenu = false, EhAlteracao = true, Menu = "Notificação", Agrupamento = "Notificação", Url = "/notificacoes")]
        N_A = 41,

        [PermissaoMenu(EhMenu = false, EhConsulta = true, Menu = "Atribuição Professor", Agrupamento = "Atribuição Professor")]
        AP_C = 42,

        [PermissaoMenu(EhMenu = false, EhInclusao = true, Menu = "Atribuição Professor", Agrupamento = "Atribuição Professor")]
        AP_I = 43,

        [PermissaoMenu(EhMenu = false, EhExclusao = true, Menu = "Atribuição Professor", Agrupamento = "Atribuição Professor")]
        AP_E = 44,

        [PermissaoMenu(EhMenu = false, EhAlteracao = true, Menu = "Atribuição Professor", Agrupamento = "Atribuição Professor")]
        AP_A = 45,

        [PermissaoMenu(Menu = "Usuários", Icone = "fas fa-user-cog", Agrupamento = "Configurações", OrdemAgrupamento = 10, OrdemMenu = 1, Url = "/usuarios/reiniciar-senha", EhAlteracao = true,
           EhSubMenu = true, EhConsulta = true, OrdemSubMenu = 1, SubMenu = "Reiniciar Senha")]
        AS_C = 47,

        [PermissaoMenu(EhMenu = false, EhConsulta = true, Menu = "Meus Dados", Agrupamento = "Meus Dados", Url = "/meus-dados")]
        M_C = 48,

        [PermissaoMenu(EhMenu = false, EhInclusao = true, Menu = "Meus Dados", Agrupamento = "Meus Dados", Url = "/meus-dados")]
        M_I = 49,

        [PermissaoMenu(EhMenu = false, EhExclusao = true, Menu = "Meus Dados", Agrupamento = "Meus Dados", Url = "/meus-dados")]
        M_E = 50,

        [PermissaoMenu(EhMenu = false, EhAlteracao = true, Menu = "Meus Dados", Agrupamento = "Meus Dados", Url = "/meus-dados")]
        M_A = 51,

        [PermissaoMenu(Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhConsulta = true, Menu = "Notas")]
        NT_C = 52,

        [PermissaoMenu(Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhInclusao = true, Menu = "Notas")]
        NT_I = 53,

        [PermissaoMenu(Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhExclusao = true, Menu = "Notas")]
        NT_E = 54,

        [PermissaoMenu(Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhAlteracao = true, Menu = "Notas")]
        NT_A = 55,

        [PermissaoMenu(EhMenu = false, Icone = "fas fa-book-reader", Agrupamento = "Registro POA", OrdemAgrupamento = 2, OrdemMenu = 3, EhConsulta = true, Menu = "Registro POA")]
        RP_C = 56,

        [PermissaoMenu(EhMenu = false, Icone = "fas fa-book-reader", Agrupamento = "Registro POA", OrdemAgrupamento = 2, OrdemMenu = 3, EhInclusao = true, Menu = "Registro POA")]
        RP_I = 57,

        [PermissaoMenu(EhMenu = false, Icone = "fas fa-book-reader", Agrupamento = "Registro POA", OrdemAgrupamento = 2, OrdemMenu = 3, EhExclusao = true, Menu = "Registro POA")]
        RP_E = 58,

        [PermissaoMenu(EhMenu = false, Icone = "fas fa-book-reader", Agrupamento = "Registro POA", OrdemAgrupamento = 2, OrdemMenu = 3, EhAlteracao = true, Menu = "Registro POA")]
        RP_A = 59,

        [PermissaoMenu(Menu = "Calendário Professor", Icone = "fas fa-calendar-alt", IconeDashBoard = "far fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 2, EhConsulta = true, Url = "/calendario-escolar/calendario-professor")]
        CP_C = 60,

        [PermissaoMenu(Menu = "Calendário Professor", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 2, EhInclusao = true, Url = "/calendario-escolar/calendario-professor")]
        CP_I = 61,

        [PermissaoMenu(Menu = "Calendário Professor", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 2, EhExclusao = true, Url = "/calendario-escolar/calendario-professor")]
        CP_E = 62,

        [PermissaoMenu(Menu = "Calendário Professor", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 2, EhAlteracao = true, Url = "/calendario-escolar/calendario-professor")]
        CP_A = 63,

        [PermissaoMenu(Menu = "Tipo de Calendário Escolar", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 3, EhConsulta = true, Url = "/calendario-escolar/tipo-calendario-escolar")]
        TCE_C = 64,

        [PermissaoMenu(Menu = "Tipo de Calendário Escolar", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 3, EhInclusao = true, Url = "/calendario-escolar/tipo-calendario-escolar")]
        TCE_I = 65,

        [PermissaoMenu(Menu = "Tipo de Calendário Escolar", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 3, EhExclusao = true, Url = "/calendario-escolar/tipo-calendario-escolar")]
        TCE_E = 66,

        [PermissaoMenu(Menu = "Tipo de Calendário Escolar", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 3, EhAlteracao = true, Url = "/calendario-escolar/tipo-calendario-escolar")]
        TCE_A = 67,

        [PermissaoMenu(Menu = "Períodos Escolares", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 4, EhConsulta = true, Url = "/calendario-escolar/periodos-escolares")]
        PE_C = 68,

        [PermissaoMenu(Menu = "Períodos Escolares", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 4, EhInclusao = true, Url = "/calendario-escolar/periodos-escolares")]
        PE_I = 69,

        [PermissaoMenu(Menu = "Períodos Escolares", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 4, EhExclusao = true, Url = "/calendario-escolar/periodos-escolares")]
        PE_E = 70,

        [PermissaoMenu(Menu = "Períodos Escolares", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 4, EhAlteracao = true, Url = "/calendario-escolar/periodos-escolares")]
        PE_A = 71,

        [PermissaoMenu(Menu = "Períodos de fechamento (Abertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 5, EhConsulta = true, Url = "/calendario-escolar/periodo-fechamento-abertura")]
        PFA_C = 72,

        [PermissaoMenu(Menu = "Períodos de fechamento (Abertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 5, EhInclusao = true, Url = "/calendario-escolar/periodo-fechamento-abertura")]
        PFA_I = 73,

        [PermissaoMenu(Menu = "Períodos de fechamento (Abertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 5, EhExclusao = true, Url = "/calendario-escolar/periodo-fechamento-abertura")]
        PFA_E = 74,

        [PermissaoMenu(Menu = "Períodos de fechamento (Abertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 5, EhAlteracao = true, Url = "/calendario-escolar/periodo-fechamento-abertura")]
        PFA_A = 75,

        [PermissaoMenu(Menu = "Períodos de fechamento (Reabertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 6, EhConsulta = true, Url = "/calendario-escolar/periodo-fechamento-reabertura")]
        PFR_C = 76,

        [PermissaoMenu(Menu = "Períodos de fechamento (Reabertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 6, EhInclusao = true, Url = "/calendario-escolar/periodo-fechamento-reabertura")]
        PFR_I = 77,

        [PermissaoMenu(Menu = "Períodos de fechamento (Reabertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 6, EhExclusao = true, Url = "/calendario-escolar/periodo-fechamento-reabertura")]
        PFR_E = 78,

        [PermissaoMenu(Menu = "Períodos de fechamento (Reabertura)", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 6, EhAlteracao = true, Url = "/calendario-escolar/periodo-fechamento-reabertura")]
        PFR_A = 79,

        [PermissaoMenu(Menu = "Tipo de Feriado", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 7, EhConsulta = true, Url = "/calendario-escolar/tipo-feriado")]
        TF_C = 80,

        [PermissaoMenu(Menu = "Tipo de Feriado", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 7, EhInclusao = true, Url = "/calendario-escolar/tipo-feriado")]
        TF_I = 81,

        [PermissaoMenu(Menu = "Tipo de Feriado", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 7, EhExclusao = true, Url = "/calendario-escolar/tipo-feriado")]
        TF_E = 82,

        [PermissaoMenu(Menu = "Tipo de Feriado", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 7, EhAlteracao = true, Url = "/calendario-escolar/tipo-feriado")]
        TF_A = 83,

        [PermissaoMenu(Menu = "Tipo de Eventos", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 8, EhConsulta = true, Url = "/calendario-escolar/tipo-eventos")]
        TE_C = 84,

        [PermissaoMenu(Menu = "Tipo de Eventos", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 8, EhInclusao = true, Url = "/calendario-escolar/tipo-eventos")]
        TE_I = 85,

        [PermissaoMenu(Menu = "Tipo de Eventos", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 8, EhExclusao = true, Url = "/calendario-escolar/tipo-eventos")]
        TE_E = 86,

        [PermissaoMenu(Menu = "Tipo de Eventos", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 8, EhAlteracao = true, Url = "/calendario-escolar/tipo-eventos")]
        TE_A = 87,

        [PermissaoMenu(Menu = "Eventos", Icone = "fas fa-calendar-alt", IconeDashBoard = "far fa-calendar-check", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 9, EhConsulta = true, Url = "/calendario-escolar/eventos")]
        E_C = 88,

        [PermissaoMenu(Menu = "Eventos", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 9, EhInclusao = true, Url = "/calendario-escolar/eventos")]
        E_I = 89,

        [PermissaoMenu(Menu = "Eventos", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 9, EhExclusao = true, Url = "/calendario-escolar/eventos")]
        E_E = 90,

        [PermissaoMenu(Menu = "Eventos", Icone = "fas fa-calendar-alt", Agrupamento = "Calendário Escolar", OrdemAgrupamento = 5, OrdemMenu = 9, EhAlteracao = true, Url = "/calendario-escolar/eventos")]
        E_A = 91,

        [PermissaoMenu(Menu = "Atribuição esporádica", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 1, EhConsulta = true, Url = "/gestao/atribuicao-esporadica")]
        AE_C = 92,

        [PermissaoMenu(Menu = "Atribuição esporádica", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 1, EhInclusao = true, Url = "/gestao/atribuicao-esporadica")]
        AE_I = 93,

        [PermissaoMenu(Menu = "Atribuição esporádica", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 1, EhExclusao = true, Url = "/gestao/atribuicao-esporadica")]
        AE_E = 94,

        [PermissaoMenu(Menu = "Atribuição esporádica", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 1, EhAlteracao = true, Url = "/gestao/atribuicao-esporadica")]
        AE_A = 95,

        [PermissaoMenu(Menu = "Atribuição de Responsáveis", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 5, EhConsulta = true, Url = "/gestao/atribuicao-responsaveis/lista")]
        ARP_C = 96,

        [PermissaoMenu(Menu = "Atribuição de Responsáveis", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 5, EhInclusao = true, Url = "/gestao/atribuicao-responsaveis/lista")]
        ARP_I = 97,

        [PermissaoMenu(Menu = "Atribuição de Responsáveis", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 5, EhExclusao = true, Url = "/gestao/atribuicao-responsaveis/lista")]
        ARP_E = 98,

        [PermissaoMenu(Menu = "Atribuição de Responsáveis", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 5, EhAlteracao = true, Url = "/gestao/atribuicao-responsaveis/lista")]
        ARP_A = 99,

        [PermissaoMenu(Menu = "Tipo de Avaliação", Icone = "fas fa-user-cog", Agrupamento = "Configurações", OrdemAgrupamento = 10, OrdemMenu = 2, EhConsulta = true, Url = "/configuracoes/tipo-avaliacao")]
        TA_C = 100,

        [PermissaoMenu(Menu = "Tipo de Avaliação", Icone = "fas fa-user-cog", Agrupamento = "Configurações", OrdemAgrupamento = 10, OrdemMenu = 2, EhInclusao = true, Url = "/configuracoes/tipo-avaliacao")]
        TA_I = 101,

        [PermissaoMenu(Menu = "Tipo de Avaliação", Icone = "fas fa-user-cog", Agrupamento = "Configurações", OrdemAgrupamento = 10, OrdemMenu = 2, EhExclusao = true, Url = "/configuracoes/tipo-avaliacao")]
        TA_E = 102,

        [PermissaoMenu(Menu = "Tipo de Avaliação", Icone = "fas fa-user-cog", Agrupamento = "Configurações", OrdemAgrupamento = 10, OrdemMenu = 2, EhAlteracao = true, Url = "/configuracoes/tipo-avaliacao")]
        TA_A = 103,

        [PermissaoMenu(Menu = "Aula prevista X Aula dada", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 4, EhInclusao = true, Url = "/diario-classe/aula-dada-aula-prevista")]
        ADAP_I = 104,

        [PermissaoMenu(Menu = "Aula prevista X Aula dada", Icone = "", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 4, EhAlteracao = true, Url = "/diario-classe/aula-dada-aula-prevista")]
        ADAP_A = 105,

        [PermissaoMenu(Menu = "Aula prevista X Aula dada", Icone = "", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 4, EhConsulta = true, Url = "/diario-classe/aula-dada-aula-prevista")]
        ADAP_C = 106,

        [PermissaoMenu(Menu = "Aula prevista X Aula dada", Icone = "", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 4, EhExclusao = true, Url = "/diario-classe/aula-dada-aula-prevista")]
        ADAP_E = 107,

        [PermissaoMenu(Menu = "Registro POA", Icone = "", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhInclusao = true, Url = "/diario-classe/registro-poa")]
        RPOA_I = 108,

        [PermissaoMenu(Menu = "Registro POA", Icone = "", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhAlteracao = true, Url = "/diario-classe/registro-poa")]
        RPOA_A = 109,

        [PermissaoMenu(Menu = "Registro POA", Icone = "", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhConsulta = true, Url = "/diario-classe/registro-poa")]
        RPOA_C = 110,

        [PermissaoMenu(Menu = "Registro POA", Icone = "", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhExclusao = true, Url = "/diario-classe/registro-poa")]
        RPOA_E = 111,

        [PermissaoMenu(Menu = "Compensação de Ausência", Icone = "", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 6, EhConsulta = true, Url = "/diario-classe/compensacao-ausencia")]
        CA_C = 112,

        [PermissaoMenu(Menu = "Compensação de Ausência", Icone = "", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 6, EhInclusao = true, Url = "/diario-classe/compensacao-ausencia")]
        CA_I = 113,

        [PermissaoMenu(Menu = "Compensação de Ausência", Icone = "", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 6, EhExclusao = true, Url = "/diario-classe/compensacao-ausencia")]
        CA_E = 114,

        [PermissaoMenu(Menu = "Compensação de Ausência", Icone = "", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 6, EhAlteracao = true, Url = "/diario-classe/compensacao-ausencia")]
        CA_A = 115,

        [PermissaoMenu(Menu = "Fechamento de Bimestre", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 1, EhConsulta = true, Url = "/fechamento/fechamento-bimestre")]
        FB_C = 124,

        [PermissaoMenu(Menu = "Fechamento de Bimestre", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 1, EhInclusao = true, Url = "/fechamento/fechamento-bimestre")]
        FB_I = 125,

        [PermissaoMenu(Menu = "Fechamento de Bimestre", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 1, EhExclusao = true, Url = "/fechamento/fechamento-bimestre")]
        FB_E = 126,

        [PermissaoMenu(Menu = "Fechamento de Bimestre", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 1, EhAlteracao = true, Url = "/fechamento/fechamento-bimestre")]
        FB_A = 127,

        [PermissaoMenu(Menu = "Pendências do Fechamento", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 2, EhConsulta = true, Url = "/fechamento/pendencias-fechamento")]
        PF_C = 128,

        [PermissaoMenu(Menu = "Pendências do Fechamento", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 2, EhInclusao = true, Url = "/fechamento/pendencias-fechamento")]
        PF_I = 129,

        [PermissaoMenu(Menu = "Pendências do Fechamento", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 2, EhExclusao = true, Url = "/fechamento/pendencias-fechamento")]
        PF_E = 130,

        [PermissaoMenu(Menu = "Pendências do Fechamento", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 2, EhAlteracao = true, Url = "/fechamento/pendencias-fechamento")]
        PF_A = 131,

        [PermissaoMenu(Menu = "Territórios do Saber", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, EhConsulta = true, Url = "/planejamento/plano-anual-territorio-saber")]
        PT_C = 132,

        [PermissaoMenu(Menu = "Territórios do Saber", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, EhInclusao = true, Url = "/planejamento/plano-anual-territorio-saber")]
        PT_I = 133,

        [PermissaoMenu(Menu = "Territórios do Saber", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, EhExclusao = true, Url = "/planejamento/plano-anual-territorio-saber")]
        PT_E = 134,

        [PermissaoMenu(Menu = "Territórios do Saber", Icone = "fas fa-list-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 2, EhAlteracao = true, Url = "/planejamento/plano-anual-territorio-saber")]
        PT_A = 135,

        [PermissaoMenu(Menu = "Conselho de Classe", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 3, EhConsulta = true, Url = "/fechamento/conselho-classe")]
        CC_C = 136,

        [PermissaoMenu(Menu = "Conselho de Classe", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 3, EhInclusao = true, Url = "/fechamento/conselho-classe")]
        CC_I = 137,

        [PermissaoMenu(Menu = "Conselho de Classe", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 3, EhExclusao = true, Url = "/fechamento/conselho-classe")]
        CC_E = 138,

        [PermissaoMenu(Menu = "Conselho de Classe", Icone = "", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 3, EhAlteracao = true, Url = "/fechamento/conselho-classe")]
        CC_A = 139,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true,
            Url = "/relatorios/pap/relatorio-semestral", EhSubMenu = true, OrdemSubMenu = 3, SubMenu = "Relatório Semestral")]
        RPS_C = 144,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhInclusao = true,
            Url = "/relatorios/pap/relatorio-semestral", EhSubMenu = true, OrdemSubMenu = 3, SubMenu = "Relatório Semestral")]
        RPS_I = 145,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhExclusao = true,
            Url = "/relatorios/pap/relatorio-semestral", EhSubMenu = true, OrdemSubMenu = 3, SubMenu = "Relatório Semestral")]
        RPS_E = 146,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = true,
            Url = "/relatorios/pap/relatorio-semestral", EhSubMenu = true, OrdemSubMenu = 3, SubMenu = "Relatório Semestral")]
        RPS_A = 147,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true,
            Url = "/relatorios/pap/relatorio-graficos", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Resumos e gráfico")]
        RPG_C = 120,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhInclusao = true,
            Url = "/relatorios/pap/relatorio-graficos", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Resumos e gráfico")]
        RPG_I = 121,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhExclusao = true,
            Url = "/relatorios/pap/relatorio-graficos", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Resumos e gráfico")]
        RPG_E = 122,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true,
            Url = "/relatorios/pap/relatorio-graficos", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Resumos e gráfico")]
        RPG_A = 123,

        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true,
            Url = "/relatorios/pap/relatorio-preenchimento", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Preenchimento")]
        RGP_C = 116,
        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhInclusao = true,
           Url = "/relatorios/pap/relatorio-preenchimento", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Preenchimento")]
        RGP_I = 117,
        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhExclusao = true,
       Url = "/relatorios/pap/relatorio-preenchimento", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Preenchimento")]
        RGP_E = 118,
        [PermissaoMenu(Menu = "PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = true,
       Url = "/relatorios/pap/relatorio-preenchimento", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Preenchimento")]
        RGP_A = 119,

        //[PermissaoMenu(Menu = "Relatório Semestral PAP", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = true, Url = "/relatorios/pap/relatorio-semestral")]
        //RSP_A = 147,

        [PermissaoMenu(Menu = "Atas", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 4, EhConsulta = true, Url = "/relatorios/atas/ata-final-resultados", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Ata Final de Resultados")]
        AFR_C = 148,

        [PermissaoMenu(Menu = "Atas", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 4, EhInclusao = true, Url = "/relatorios/atas/ata-final-resultados", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Ata Final de Resultados")]
        AFR_I = 149,

        [PermissaoMenu(Menu = "Atas", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 4, EhExclusao = true, Url = "/relatorios/atas/ata-final-resultados", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Ata Final de Resultados")]
        AFR_E = 150,

        [PermissaoMenu(Menu = "Ata Final de Resultados", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 4, EhAlteracao = true, Url = "/relatorios/atas/ata-final-resultados")]
        AFR_A = 151,

        [PermissaoMenu(Menu = "Histórico Escolar", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 5, EhConsulta = true, Url = "/relatorios/historico-escolar")]
        HE_C = 152,

        [PermissaoMenu(Menu = "Histórico Escolar", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 5, EhInclusao = true, Url = "/relatorios/historico-escolar")]
        HE_I = 153,

        [PermissaoMenu(Menu = "Histórico Escolar", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 5, EhExclusao = true, Url = "/relatorios/historico-escolar")]
        HE_E = 154,

        [PermissaoMenu(Menu = "Histórico Escolar", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 5, EhAlteracao = true, Url = "/relatorios/historico-escolar")]
        HE_A = 155,

        [PermissaoMenu(Menu = "Frequência", Icone = "fas fa-print", IconeDashBoard = "far fa-check-square", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/frequencia/frequencia", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Frequência")]
        FF_C = 156,

        [PermissaoMenu(Menu = "Gestão", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true, Url = "/relatorios/gestao/pendencias", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Pendências")]
        RPF_C = 157,

        [PermissaoMenu(Menu = "Fechamento", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true, Url = "/relatorios/parecer-conclusivo", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Parecer Conclusivo")]
        RPC_C = 158,

        [PermissaoMenu(Menu = "Diário de Bordo (Intencionalidade docente)", Icone = "fas fa-file-alt", IconeDashBoard = "far fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhConsulta = true, Url = "/diario-classe/diario-bordo")]
        DDB_C = 159,

        [PermissaoMenu(Menu = "Diário de Bordo (Intencionalidade docente)", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhInclusao = true, Url = "/diario-classe/diario-bordo")]
        DDB_I = 160,

        [PermissaoMenu(Menu = "Diário de Bordo (Intencionalidade docente)", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhExclusao = true, Url = "/diario-classe/diario-bordo")]
        DDB_E = 161,

        [PermissaoMenu(Menu = "Diário de Bordo (Intencionalidade docente)", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 2, EhAlteracao = true, Url = "/diario-classe/diario-bordo")]
        DDB_A = 162,

        [PermissaoMenu(Menu = "Carta de Intenções", Icone = "fas fa-file-alt", IconeDashBoard = "far fa-envelope-open", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhConsulta = true, Url = "/planejamento/carta-intencoes")]
        CI_C = 163,

        [PermissaoMenu(Menu = "Carta de Intenções", Icone = "fas fa-file-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhInclusao = true, Url = "/planejamento/carta-intencoes")]
        CI_I = 164,

        [PermissaoMenu(Menu = "Carta de Intenções", Icone = "fas fa-file-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhExclusao = true, Url = "/planejamento/carta-intencoes")]
        CI_E = 165,

        [PermissaoMenu(Menu = "Carta de Intenções", Icone = "fas fa-file-alt", Agrupamento = "Planejamento", OrdemAgrupamento = 2, OrdemMenu = 3, EhAlteracao = true, Url = "/planejamento/carta-intencoes")]
        CI_A = 166,

        [PermissaoMenu(Menu = "Devolutivas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 3, EhConsulta = true, Url = "/diario-classe/devolutiva")]
        DE_C = 167,

        [PermissaoMenu(Menu = "Devolutivas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 3, EhInclusao = true, Url = "/diario-classe/devolutiva")]
        DE_I = 168,

        [PermissaoMenu(Menu = "Devolutivas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 3, EhExclusao = true, Url = "/diario-classe/devolutiva")]
        DE_E = 169,

        [PermissaoMenu(Menu = "Devolutivas", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 3, EhAlteracao = true, Url = "/diario-classe/devolutiva")]
        DE_A = 170,

        [PermissaoMenu(Menu = "Fechamento", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true, Url = "/relatorios/notas-conceitos-finais", EhSubMenu = true, OrdemSubMenu = 3, SubMenu = "Notas e Conceitos Finais")]
        RNCF_C = 171,

        [PermissaoMenu(Menu = "Frequência", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/compensacao-ausencia", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Compensação de ausência")]
        RCA_C = 172,

        [PermissaoMenu(Menu = "Diario classe", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/diario-classe/controle-grade", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Controle de Grade")]
        RCG_C = 173,

        [PermissaoMenu(Menu = "Documentos e planos de trabalho", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhConsulta = true, Url = "/gestao/documentos-planos-trabalho")]
        DPU_C = 177,

        [PermissaoMenu(Menu = "Documentos e planos de trabalho", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhInclusao = true, Url = "/gestao/documentos-planos-trabalho")]
        DPU_I = 178,

        [PermissaoMenu(Menu = "Documentos e planos de trabalho", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhExclusao = true, Url = "/gestao/documentos-planos-trabalho")]
        DPU_E = 179,

        [PermissaoMenu(Menu = "Documentos e planos de trabalho", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhAlteracao = true, Url = "/gestao/documentos-planos-trabalho")]
        DPU_A = 180,

        [PermissaoMenu(Menu = "Escola aqui", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, OrdemMenu = 1, EhAlteracao = false, Url = "/dashboard/escola-aqui")]
        RDE_A = 181,

        [PermissaoMenu(Menu = "Gestão", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/gestao/usuarios", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Usuários")]
        RDU_C = 182,

        [PermissaoMenu(Menu = "Notificações ", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/notificacoes/historico-notificacoes", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Histórico de notificações")]
        RDN_C = 183,

        [PermissaoMenu(Menu = "Fechamento", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true, Url = "/relatorios/fechamento/historico-alteracao-notas", EhSubMenu = true, OrdemSubMenu = 4, SubMenu = "Relatório de alterações de notas")]
        RDA_C = 184,

        [PermissaoMenu(Menu = "Escola aqui", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/escola-aqui/leitura", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Leitura")]
        RLC_C = 185,

        [PermissaoMenu(Menu = "Gestão", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/gestao/atribuicao-cj", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Atribuições")]
        RACJ_C = 186,

        [PermissaoMenu(Menu = "Escola aqui", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/escola-aqui/adesao", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Adesão")]
        RDE_C = 187,

        [PermissaoMenu(Menu = "Registro Individual", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 7, EhConsulta = true, Url = "/diario-classe/registro-individual")]
        REI_C = 189,

        [PermissaoMenu(Menu = "Registro Individual", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 7, EhInclusao = true, Url = "/diario-classe/registro-individual")]
        REI_I = 190,

        [PermissaoMenu(Menu = "Registro Individual", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 7, EhExclusao = true, Url = "/diario-classe/registro-individual")]
        REI_E = 191,

        [PermissaoMenu(Menu = "Registro Individual", Icone = "fas fa-file-alt", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 7, EhAlteracao = true, Url = "/diario-classe/registro-individual")]
        REI_A = 192,

        [PermissaoMenu(Menu = "Diario classe", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/diario-classe/planejamento-diario", EhSubMenu = true, OrdemSubMenu = 3, SubMenu = "Controle de planejamento diário")]
        RCP_C = 188,

        [PermissaoMenu(Menu = "Ocorrências", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhConsulta = true, Url = "/gestao/ocorrencias")]
        OCO_C = 193,

        [PermissaoMenu(Menu = "Ocorrências", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhInclusao = true, Url = "/gestao/ocorrencias")]
        OCO_I = 194,

        [PermissaoMenu(Menu = "Ocorrências", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhExclusao = true, Url = "/gestao/ocorrencias")]
        OCO_E = 195,

        [PermissaoMenu(Menu = "Ocorrências", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, EhAlteracao = true, Url = "/gestao/ocorrencias")]
        OCO_A = 196,

        [PermissaoMenu(Menu = "Encaminhamento", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 1, EhConsulta = true, Url = "/aee/encaminhamento")]
        AEE_C = 197,

        [PermissaoMenu(Menu = "Encaminhamento", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 1, EhInclusao = true, Url = "/aee/encaminhamento")]
        AEE_I = 198,

        [PermissaoMenu(Menu = "Encaminhamento", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 1, EhExclusao = true, Url = "/aee/encaminhamento")]
        AEE_E = 199,

        [PermissaoMenu(Menu = "Encaminhamento", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 1, EhAlteracao = true, Url = "/aee/encaminhamento")]
        AEE_A = 200,

        [PermissaoMenu(Menu = "Acompanhamento de frequência", Icone = "fas fa-user-cog", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 7, EhConsulta = true, Url = "/diario-classe/acompanhamento-frequencia")]
        AFQ_C = 201,

        [PermissaoMenu(Menu = "Plano", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 2, EhConsulta = true, Url = "/aee/plano")]
        PAEE_C = 202,

        [PermissaoMenu(Menu = "Plano", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 2, EhInclusao = true, Url = "/aee/plano")]
        PAEE_I = 203,

        [PermissaoMenu(Menu = "Plano", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 2, EhExclusao = true, Url = "/aee/plano")]
        PAEE_E = 204,

        [PermissaoMenu(Menu = "Plano", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 2, EhAlteracao = true, Url = "/aee/plano")]
        PAEE_A = 205,
        
        [PermissaoMenu(Menu = "Registro de itinerância", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 3, EhConsulta = true, Url = "/aee/registro-itinerancia")]
        RI_C = 206,

        [PermissaoMenu(Menu = "Registro de itinerância", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 3, EhInclusao = true, Url = "/aee/registro-itinerancia")]
        RI_I = 207,

        [PermissaoMenu(Menu = "Registro de itinerância", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 3, EhExclusao = true, Url = "/aee/registro-itinerancia")]
        RI_E = 208,

        [PermissaoMenu(Menu = "Registro de itinerância", Icone = "fas fa-universal-access", Agrupamento = "AEE", OrdemAgrupamento = 7, OrdemMenu = 3, EhAlteracao = true, Url = "/aee/registro-itinerancia")]
        RI_A = 209,

        [PermissaoMenu(Menu = "Relatório do Acompanhamento da Aprendizagem", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 5, EhConsulta = true, Url = "/fechamento/acompanhamento-aprendizagem")]
        RAA_C = 210,

        [PermissaoMenu(Menu = "Relatório do Acompanhamento da Aprendizagem", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 5, EhInclusao = true, Url = "/fechamento/acompanhamento-aprendizagem")]
        RAA_I = 211,

        [PermissaoMenu(Menu = "Relatório do Acompanhamento da Aprendizagem", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 5, EhExclusao = true, Url = "/fechamento/acompanhamento-aprendizagem")]
        RAA_E = 212,

        [PermissaoMenu(Menu = "Relatório do Acompanhamento da Aprendizagem", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, OrdemMenu = 5, EhAlteracao = true, Url = "/fechamento/acompanhamento-aprendizagem")]
        RAA_A = 213,

        [PermissaoMenu(Menu = "Diario classe", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true, Url = "/relatorios/planejamento/devolutivas", EhSubMenu = true, OrdemSubMenu = 3, SubMenu = "Devolutivas")]
        RD_C = 214,

        [PermissaoMenu(Menu = "AEE", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/aee")]
        DAEE_C = 215,

        [PermissaoMenu(Menu = "Registro de Itinerância", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/registro-itinerancia")]
        DRI_C = 216,

        [PermissaoMenu(Menu = "Frequência", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/frequencia")]
        DF_C = 217,

        [PermissaoMenu(Menu = "Acompanhamento do fechamento", Icone = "fas fa-pencil-ruler", Agrupamento = "Fechamento", OrdemAgrupamento = 3, EhConsulta = true, Url = "/fechamento/acompanhamento-fechamento")]
        ACF_C = 218,

        [PermissaoMenu(Menu = "Informações Escolares", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/informacoes-escolares")]
        DIE_C = 219,

        [PermissaoMenu(Menu = "Devolutivas", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/devolutivas")]
        DD_C = 220,

        [PermissaoMenu(Menu = "Diário de Bordo", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/diario-bordo")]
        DB_C = 222,

        [PermissaoMenu(Menu = "Registro Individual", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/registro-individual")]
        DRIN_C = 221,

        [PermissaoMenu(Menu = "Relatório de Acompanhamento de Aprendizagem", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/acompanhamento-aprendizagem")]
        DAA_C = 223,

        [PermissaoMenu(Menu = "Fechamento", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhConsulta = true, Url = "/relatorios/fechamentos/acompanhamento-fechamento", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Acompanhamento do fechamento")]
        RACF_C = 224,
        
        [PermissaoMenu(Menu = "Fechamento", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/fechamento")]
        DFE_C = 225,

        [PermissaoMenu(Menu = "Atas", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 4, EhConsulta = true, Url = "/relatorios/atas/ata-bimestral", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Ata bimestral")]
        ABR_C = 226,

        [PermissaoMenu(Menu = "Gestão", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/gestao/acompanhamento-registros", EhSubMenu = true, OrdemSubMenu = 1, SubMenu = "Acompanhamento dos registros")]
        RRP_C = 227,

        [PermissaoMenu(Menu = "Listão", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 8, EhConsulta = true, Url = "/diario-classe/listao", IconeDashBoard = "far fa-check-square")]
        L_C = 228,

        [PermissaoMenu(Menu = "Listão", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 8, EhInclusao = true, Url = "/diario-classe/listao")]
        L_I = 229,

        [PermissaoMenu(Menu = "Listão", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 8, EhExclusao = true, Url = "/diario-classe/listao")]
        L_E = 230,

        [PermissaoMenu(Menu = "Listão", Icone = "fas fa-book-reader", Agrupamento = "Diário de Classe", OrdemAgrupamento = 1, OrdemMenu = 8, EhAlteracao = true, Url = "/diario-classe/listao")]
        L_A = 231,

        [PermissaoMenu(Menu = "Frequência", Icone = "fas fa-print", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 2, EhAlteracao = false, Url = "/relatorios/frequencia/mensal", EhSubMenu = true, OrdemSubMenu = 2, SubMenu = "Frequência mensal")]
        RFM_C = 232,

        [PermissaoMenu(Menu = "NAAPA", Icone = "fas fa-chart-bar", Agrupamento = "Dashboard", OrdemAgrupamento = 9, EhConsulta = true, Url = "/dashboard/naapa")]
        DNA_C = 233,

        [PermissaoMenu(Menu = "Usuários", Icone = "fas fa-user-cog", Agrupamento = "Configurações", OrdemAgrupamento = 10, OrdemMenu = 1, OrdemSubMenu = 2,
            Url = "/usuarios/suporte", EhSubMenu = true, EhConsulta = true, EhInclusao = true, SubMenu = "Suporte")]
        US_C = 234,

        [PermissaoMenu(Menu = "NAAPA", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 7, OrdemSubMenu = 1, EhConsulta = true, Url = "/naapa/encaminhamento", EhSubMenu = true, SubMenu = "Encaminhamento")]
        NAAPA_C = 235,

        [PermissaoMenu(Menu = "NAAPA", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 7, OrdemSubMenu = 1, EhInclusao = true, Url = "/naapa/encaminhamento", EhSubMenu = true, SubMenu = "Encaminhamento")]
        NAAPA_I = 236,

        [PermissaoMenu(Menu = "NAAPA", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 7, OrdemSubMenu = 1, EhExclusao = true, Url = "/naapa/encaminhamento", EhSubMenu = true, SubMenu = "Encaminhamento")]
        NAAPA_E = 237,

        [PermissaoMenu(Menu = "NAAPA", Icone = "fas fa-tasks", Agrupamento = "Gestão", OrdemAgrupamento = 6, OrdemMenu = 7, OrdemSubMenu = 1, EhAlteracao = true, Url = "/naapa/encaminhamento", EhSubMenu = true, SubMenu = "Encaminhamento")]
        NAAPA_A = 238,
        
        [PermissaoMenu(Menu = "AEE", Icone = "fas fa-tasks", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 1, OrdemSubMenu = 1, EhAlteracao = false, Url = "/relatorios/aee/plano", EhSubMenu = true, SubMenu = "Plano")]
        RPAEE_C = 239,

        [PermissaoMenu(Menu = "AEE", Icone = "fas fa-tasks", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 1, OrdemSubMenu = 2, EhAlteracao = false, Url = "/relatorios/aee/encaminhamento", EhSubMenu = true, SubMenu = "Encaminhamento")]
        REAEE_C = 240,

        [PermissaoMenu(Menu = "NAAPA", Icone = "fas fa-tasks", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 1, OrdemSubMenu = 1, EhAlteracao = false, EhConsulta = true, Url = "/relatorios/naapa/encaminhamento", EhSubMenu = true, SubMenu = "Encaminhamento")]
        RENAAPA_C = 241,
        
        [PermissaoMenu(Menu = "SONDAGEM", Icone = "fas fa-tasks", Agrupamento = "Relatórios", OrdemAgrupamento = 8, OrdemMenu = 1, OrdemSubMenu = 1, EhAlteracao = false, EhConsulta = true, Url = "/relatorios/sondagem/analitico", EhSubMenu = true, SubMenu = "Relatório Analítico")]
        RESON_C = 242
    }
}