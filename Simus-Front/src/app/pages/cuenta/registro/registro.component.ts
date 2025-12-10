import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  registroForm: FormGroup;
  passwordVisible = false;
  confirmPasswordVisible = false;
  imagePreview: string | ArrayBuffer | null = null;
  isDragging = false;

  // Mock data for dropdowns - this should come from a service eventually
  tiposDocumento = ['Cédula de Ciudadanía', 'Tarjeta de Identidad', 'Cédula de Extranjería', 'Pasaporte'];
  paises = ['Colombia']; // Assuming Colombia for now
  departamentos: string[] = []; // Should be loaded based on country
  municipios: string[] = []; // Should be loaded based on department

  constructor(private fb: FormBuilder) {
    this.registroForm = this.fb.group({
      // Datos Personales
      primerNombre: ['', Validators.required],
      segundoNombre: [''],
      primerApellido: ['', Validators.required],
      segundoApellido: [''],
      fechaNacimiento: [''],
      tipoDocumento: ['', Validators.required],
      numeroDocumento: ['', Validators.required],
      sexo: [''],
      imagenPerfil: [null],

      // Datos de Autenticación
      usuario: ['', [Validators.required, Validators.email]],
      confcorreo: ['', [Validators.required, Validators.email]],
      contrasena: ['', [Validators.required, Validators.minLength(8)]], // Add more complex regex later
      confcontrasena: ['', Validators.required],

      // Datos de Ubicación
      pais: ['', Validators.required],
      departamento: [''],
      municipio: [''],

      // Términos y Condiciones
      aceptaCondiciones: [false, Validators.requiredTrue]
    }, { validators: [this.passwordMatchValidator, this.emailMatchValidator] });
  }

  ngOnInit(): void {
    this.setupEmailSuggestions();
    // Here you would typically load dropdown data from services
  }

  passwordMatchValidator(form: FormGroup) {
    const password = form.get('contrasena');
    const confirmPassword = form.get('confcontrasena');
    return password && confirmPassword && password.value === confirmPassword.value ? null : { mismatch: true };
  }

  emailMatchValidator(form: FormGroup) {
    const email = form.get('usuario');
    const confirmEmail = form.get('confcorreo');
    return email && confirmEmail && email.value === confirmEmail.value ? null : { emailMismatch: true };
  }

  // --- Email Domain Suggestions ---
  suggestedDomains = ['mincultura.gov.co', 'gmail.com', 'hotmail.com', 'outlook.com', 'yahoo.com'];
  emailSuggestions: string[] = [];
  showDomainSuggestions = false;

  private setupEmailSuggestions(): void {
    this.registroForm.get('usuario')?.valueChanges.subscribe(value => {
      if (value && value.includes('@')) {
        const [name, domainPart] = value.split('@');
        const filteredDomains = this.suggestedDomains.filter(d => d.startsWith(domainPart || ''));
        this.emailSuggestions = filteredDomains.map(d => `${name}@${d}`);
        this.showDomainSuggestions = true;
      } else {
        this.emailSuggestions = [];
        this.showDomainSuggestions = false;
      }
    });
  }

  selectDomain(domain: string): void {
    this.registroForm.get('usuario')?.setValue(domain);
    this.showDomainSuggestions = false;
    this.emailSuggestions = [];
  }

  // --- Image Upload Logic ---
  onFileChange(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.processFile(file);
    }
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.isDragging = true;
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.isDragging = false;
  }

  onDrop(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.isDragging = false;
    const file = event.dataTransfer?.files[0];
    if (file) {
      this.processFile(file);
    }
  }

  processFile(file: File): void {
    this.registroForm.patchValue({ imagenPerfil: file });
    const reader = new FileReader();
    reader.onload = () => {
      this.imagePreview = reader.result;
    };
    reader.readAsDataURL(file);
  }

  removeImage(): void {
    this.imagePreview = null;
    this.registroForm.patchValue({ imagenPerfil: null });
  }
  
  // --- Form Submission ---
  onSubmit(): void {
    if (this.registroForm.valid) {
      console.log('Formulario enviado', this.registroForm.value);
      // Here you would call your registration service
    } else {
      console.log('Formulario inválido');
      this.registroForm.markAllAsTouched();
    }
  }
}
